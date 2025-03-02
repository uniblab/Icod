using System.Runtime.CompilerServices;

namespace Icod.Threading {

	/// <include file='..\..\doc\Icod.Threading.xml' path='types/type[@name="Icod.Threading.SharedLock"]/member[@name=""]/*'/>
	[Icod.Author( "Timothy J. ``Flytrap\'\' Bruce" )]
	[Icod.ReportBugsTo( "mailto:uniblab@hotmail.com" )]
	[Icod.LgplLicense]
	public class SharedLock : IAsynchronousSharedLock {

		#region fields
		private static readonly VolatileRead theReader;

		private System.Int32 State = 0;

		private const System.Int32 ShareBit = 0x1000000;
		private const System.Int32 ExcludeBit = 0x2000000;
		private const System.Int32 StatusBitMask = SharedLock.ShareBit | SharedLock.ExcludeBit;

		private const System.Int32 Excluder = 0x01;
		private const System.Int32 ExcludeMask = 0xff;
		private const System.Int32 ExcludeOffset = 0;

		private const System.Int32 Sharer = 0x0100;
		private const System.Int32 ShareMask = 0xff00;
		private const System.Int32 ShareOffset = SharedLock.ExcludeOffset + 8;

		private const System.Int32 WaitingSharer = 0x010000;
		private const System.Int32 WaitingShareMask = 0xff0000;
		private const System.Int32 WaitingShareOffset = SharedLock.ShareOffset + 8;

#if NET5_0
		private System.Threading.AutoResetEvent excludeLock = new( true );
#else
		private System.Threading.AutoResetEvent excludeLock = new System.Threading.AutoResetEvent( true );
#endif
#if NET5_0
		private System.Threading.ManualResetEvent shareLock = new( true );
#else
		private System.Threading.ManualResetEvent shareLock = new System.Threading.ManualResetEvent( true );
#endif
#if NET5_0
		private System.Threading.Semaphore waitLock = new( 0, System.Byte.MaxValue );
#else
		private System.Threading.Semaphore waitLock = new System.Threading.Semaphore( 0, System.Byte.MaxValue );
#endif
		#endregion fields


		#region .ctor
		static SharedLock() {
#if NET8_0_OR_GREATER
			theReader = System.Threading.Volatile.Read;
#elif NET45_OR_GREATER || NETCOREAPP || NETSTANDARD || NET5_0_OR_GREATER
			theReader = System.Threading.Volatile.Read;
#else
			theReader = System.Threading.Thread.VolatileRead;
#endif
		}

		/// <include file='..\..\doc\Icod.Threading.xml' path='types/type[@name="Icod.Threading.SharedLock"]/member[@name="#ctor"]/*'/>
		public SharedLock() {
		}
		/// <include file='..\..\doc\Icod.Threading.xml' path='types/type[@name="Icod.Threading.SharedLock"]/member[@name="#dtor"]/*'/>
		~SharedLock() {
			this.Dispose( false );
		}
		#endregion .ctor


		#region methods
		#region exclude
		public void Enter() {
			this.EnterExclusive();
		}
		public void Exit() {
			this.ExitExclusive();
		}

		private void EnterExclusive() {
			this.IncExcluder();
			do {
				_ = shareLock.Reset();
				if ( !excludeLock.WaitOne() ) {
					throw new System.ObjectDisposedException( null );
				}
			} while ( 0 != ( Icod.Threading.SharedLock.ShareMask & theReader( ref this.State ) ) );
		}

		private void ExitExclusive() {
			_ = excludeLock.Set();
			System.Int32 waitingShares = this.DecExcluder();
			if ( 0 < waitingShares ) {
				_ = waitLock.Release( waitingShares );
			}
			if ( Icod.Threading.SharedLock.ExcludeBit != ( Icod.Threading.SharedLock.ExcludeBit & theReader( ref this.State ) ) ) {
				_ = shareLock.Set();
			}
		}

		/// <include file='..\..\doc\Icod.Threading.xml' path='types/type[@name="Icod.Threading.ISynchronousSharedLock"]/member[@name="Exclude"]/*'/>
		public virtual System.IDisposable Exclude() {
			this.EnterExclusive();
			return new LockExit( this.ExitExclusive );
		}
		#region APM
		/// <include file='..\..\doc\Icod.Threading.xml' path='types/type[@name="Icod.Threading.IAsynchronousSharedLock"]/member[@name="BeginExclude(System.AsyncCallback,System.Object)"]/*'/>
		public System.IAsyncResult BeginExclude( System.AsyncCallback callback, System.Object state ) {
			Icod.Threading.LockResult output = new Icod.Threading.LockResult( callback, state );
			_ = System.Threading.ThreadPool.QueueUserWorkItem( this.ExcludeHelper, output );
			if ( output.IsCompleted ) {
				output.SetSynchronousCopmpletion( true );
			}
			return output;
		}
		private void ExcludeHelper( System.Object asyncResult ) {
#if NET9_0_OR_GREATER
			System.ArgumentNullException.ThrowIfNull( asyncResult, nameof( asyncResult ) );
#else
			if ( null == asyncResult ) {
				throw new System.ArgumentNullException( nameof( asyncResult ) );
			}
#endif
			Icod.Threading.LockResult input = ( asyncResult as Icod.Threading.LockResult ) ?? throw new System.ArgumentNullException( nameof( asyncResult ) );
			try {
				System.IDisposable result = this.Exclude();
				input.Complete( result, false, null );
			} catch ( System.Exception e ) {
				input.Complete( false, e );
			}
		}
		/// <include file='..\..\doc\Icod.Threading.xml' path='types/type[@name="Icod.Threading.IAsynchronousSharedLock"]/member[@name="EndExclude(System.IAsyncResult)"]/*'/>
		public System.IDisposable EndExclude( System.IAsyncResult result ) {
			if ( null == result ) {
				throw new System.ArgumentNullException( nameof( result ) );
			}
			Icod.Threading.LockResult input = ( result as Icod.Threading.LockResult ) ?? throw new System.ArgumentNullException( nameof( result ) );
			return input.End();
		}
		#endregion APM

		private void IncExcluder() {
			System.Int32 current;
			System.Int32 desired;
			do {
				_ = shareLock.Reset(); // blocks any future shares until we are done excluding
				current = theReader( ref this.State );
				desired = ( ( current | SharedLock.ExcludeBit ) + SharedLock.Excluder );
			} while ( false == Icod.Threading.Interlocked.ExchangeCompare( ref this.State, current, desired ) );
		}
		///<returns>the number of waiting readers</returns>
		private System.Int32 DecExcluder() {
			System.Int32 current;
			System.Int32 desired;
			do {
				current = theReader( ref this.State );
				if ( 0 == ( Icod.Threading.SharedLock.ExcludeMask & current ) ) {
					throw new System.InvalidOperationException();
				}
				desired = current;
				if ( Icod.Threading.SharedLock.Excluder == ( Icod.Threading.SharedLock.ExcludeMask & Icod.Threading.Interlocked.Subtract( ref desired, Icod.Threading.SharedLock.Excluder ) ) ) {
					_ = Icod.Threading.Interlocked.And( ref desired, ~Icod.Threading.SharedLock.ExcludeBit );
				}
			} while ( false == Icod.Threading.Interlocked.ExchangeCompare( ref this.State, current, desired ) );
			return ( ( Icod.Threading.SharedLock.WaitingShareMask & theReader( ref this.State ) ) >> Icod.Threading.SharedLock.WaitingShareOffset );
		}
		#endregion write

		#region share
		private void EnterShare() {
			_ = excludeLock.Reset();
			// if there are no excluders, then we can immediately share;
			// otherwise, we are enqueuing a waitingsharer
			do {
				if ( Icod.Threading.SharedLock.ExcludeBit == ( Icod.Threading.SharedLock.ExcludeBit & theReader( ref this.State ) ) ) {
					this.IncWaitingSharer();
					if ( !waitLock.WaitOne() ) {
						throw new System.ObjectDisposedException( null );
					}
					this.DecWaitingSharer();
				}
				if ( Icod.Threading.SharedLock.ExcludeBit != ( Icod.Threading.SharedLock.ExcludeBit & theReader( ref this.State ) ) ) {
					this.IncSharer();
					if ( !shareLock.WaitOne() ) {
						throw new System.ObjectDisposedException( null );
					}
					break;
				}
			} while ( true );
		}
		private void ExitShare() {
			if ( 0 == this.DecSharer() ) {
				System.Int32 waiters = ( SharedLock.WaitingShareMask & theReader( ref this.State ) ) >> SharedLock.WaitingShareOffset;
				if ( 0 < waiters ) {
					_ = this.waitLock.Release( waiters );
				}
			}
			if ( 0 == ( SharedLock.ShareMask & theReader( ref this.State ) ) ) {
				_ = excludeLock.Set();
			}
		}
		/// <include file='..\..\doc\Icod.Threading.xml' path='types/type[@name="Icod.Threading.ISynchronousSharedLock"]/member[@name="Share"]/*'/>
		public virtual System.IDisposable Share() {
			this.EnterShare();
			return new LockExit( this.ExitShare );
		}

		#region APM
		/// <include file='..\..\doc\Icod.Threading.xml' path='types/type[@name="Icod.Threading.IAsynchronousSharedLock"]/member[@name="BeginShare(System.AsyncCallback,System.Object)"]/*'/>
		public System.IAsyncResult BeginShare( System.AsyncCallback callback, System.Object state ) {
			Icod.Threading.LockResult output = new Icod.Threading.LockResult( callback, state );
			_ = System.Threading.ThreadPool.QueueUserWorkItem( this.ShareHelper, output );
			if ( output.IsCompleted ) {
				output.SetSynchronousCopmpletion( true );
			}
			return output;
		}
		private void ShareHelper( System.Object asyncResult ) {
			if ( null == asyncResult ) {
				throw new System.ArgumentNullException( nameof( asyncResult ) );
			}
			Icod.Threading.LockResult input = ( asyncResult as Icod.Threading.LockResult ) ?? throw new System.ArgumentNullException( nameof( asyncResult ) );
			try {
				System.IDisposable result = this.Share();
				input.Complete( result, false, null );
			} catch ( System.Exception e ) {
				input.Complete( false, e );
			}
		}
		/// <include file='..\..\doc\Icod.Threading.xml' path='types/type[@name="Icod.Threading.IAsynchronousSharedLock"]/member[@name="EndShare(System.IAsyncResult)"]/*'/>
		public System.IDisposable EndShare( System.IAsyncResult result ) {
			if ( null == result ) {
				throw new System.ArgumentNullException( nameof( result ) );
			}
			Icod.Threading.LockResult input = ( result as Icod.Threading.LockResult ) ?? throw new System.ArgumentNullException( nameof( result ) );
			return input.End();
		}
		#endregion APM


		private void IncWaitingSharer() {
			System.Int32 current;
			System.Int32 desired;
			do {
				current = theReader( ref this.State );
				desired = ( ( current | SharedLock.ShareBit ) + SharedLock.WaitingSharer );
			} while ( false == Icod.Threading.Interlocked.ExchangeCompare( ref this.State, current, desired ) );
		}
		private void IncSharer() {
			System.Int32 current;
			System.Int32 desired;
			do {
				current = theReader( ref this.State );
				desired = ( ( current | Icod.Threading.SharedLock.ShareBit ) + Icod.Threading.SharedLock.Sharer );
			} while ( false == Icod.Threading.Interlocked.ExchangeCompare( ref this.State, current, desired ) );
		}
		private void DecWaitingSharer() {
			System.Int32 current;
			System.Int32 desired;
			do {
				current = theReader( ref this.State );
				if ( 0 == ( Icod.Threading.SharedLock.WaitingShareMask & current ) ) {
					throw new System.InvalidOperationException();
				}
				desired = current - Icod.Threading.SharedLock.WaitingSharer;
			} while ( false == Icod.Threading.Interlocked.ExchangeCompare( ref this.State, current, desired ) );
		}
		///<returns>number of writers</returns>
		private System.Int32 DecSharer() {
			System.Int32 current;
			System.Int32 desired;
			do {
				current = theReader( ref this.State );
				if ( 0 == ( Icod.Threading.SharedLock.ShareMask & current ) ) {
					throw new System.InvalidOperationException();
				}
				desired = current;
				if ( Icod.Threading.SharedLock.Sharer == ( ( Icod.Threading.SharedLock.WaitingShareMask | Icod.Threading.SharedLock.ShareMask ) & Icod.Threading.Interlocked.Subtract( ref desired, Icod.Threading.SharedLock.Sharer ) ) ) {
					_ = Icod.Threading.Interlocked.And( ref desired, ~Icod.Threading.SharedLock.ShareBit );
				}
			} while ( false == Icod.Threading.Interlocked.ExchangeCompare( ref this.State, current, desired ) );
			return ( Icod.Threading.SharedLock.ExcludeMask & theReader( ref this.State ) );
		}
		#endregion read

		#region dispose
		/// <include file='..\..\doc\Icod.Threading.xml' path='types/type[@name="Icod.Threading.SynchronousLockBase"]/member[@name="Dispose"]/*'/>
		public void Dispose() {
			this.Dispose( true );
			System.GC.SuppressFinalize( this );
		}
		/// <include file='..\..\doc\Icod.Threading.xml' path='types/type[@name="Icod.Threading.SynchronousLockBase"]/member[@name="Dispose(System.Boolean)"]/*'/>
		private void Dispose( System.Boolean disposing ) {
			if ( true == disposing ) {
				System.Threading.Thread.BeginCriticalRegion();
				if ( null != waitLock ) {
					waitLock.Close();
					waitLock = null;
				}
				if ( null != shareLock ) {
					shareLock.Close();
					shareLock = null;
				}
				if ( null != excludeLock ) {
					excludeLock.Close();
					excludeLock = null;
				}
				System.Threading.Thread.EndCriticalRegion();
			}
		}
		#endregion dispose
		#endregion methods

	}

}