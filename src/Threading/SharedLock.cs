/*
	copyright (c) 2025 Timothy J. ``Flytrap'' Bruce of the ICOD
	written by Timothy J. ``Flytrap'' Bruce
	uniblab@hotmail.com
*/
/*
This library is free software; you can redistribute it and/or
 modify it under the terms of the GNU Lesser General Public
 License as published by the Free Software Foundation; either
 version 3 of the License, or (at your option) any later version.  

This library is distributed in the hope that it will be useful,
 but WITHOUT ANY WARRANTY; without even the implied warranty of
 MERCHANTABILITY of FITNESS FOR A PARTICULAR PURPOSE.  See the GNU
 Lesser General Public License for more details.  

You should have received a copy of the GNU Lesser General Public
 License along with this library; if not, write to the Free Software
 Foundation, Inc., 51 Franklin Street, Fifth Floor, Boston, MA 02110-1301 USA
*/

namespace Icod.Threading {

	/// <include file='..\..\doc\Icod.Threading.xml' path='types/type[@name="Icod.Threading.SharedLock"]/member[@name=""]/*'/>
	[Icod.Author( "Timothy J. ``Flytrap\'\' Bruce" )]
	[Icod.ReportBugsTo( "mailto:uniblab@hotmail.com" )]
	[Icod.LgplLicense]
	public class SharedLock : IAsynchronousSharedLock {

		#region fields
		private static readonly VolatileRead theReader;
#pragma warning disable IDE0044
		private System.Int32 State = 0;
#pragma warning restore IDE0044

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

#pragma warning disable IDE0044
		private System.Boolean myIsDisposed = false;
#pragma warning restore IDE0044

		private readonly System.Threading.AutoResetEvent myExcludeLock;
		private readonly System.Threading.ManualResetEvent myShareLock;
		private readonly System.Threading.Semaphore myWaitLock;
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
			myExcludeLock = new System.Threading.AutoResetEvent( true );
			myShareLock = new System.Threading.ManualResetEvent( true );
			myWaitLock = new System.Threading.Semaphore( 0, System.Byte.MaxValue );
		}
		/// <include file='..\..\doc\Icod.Threading.xml' path='types/type[@name="Icod.Threading.SharedLock"]/member[@name="#dtor"]/*'/>
		~SharedLock() {
			this.Dispose( false );
		}
		#endregion .ctor


		#region methods
		#region exclude
		/// <include file='..\..\doc\Icod.Threading.xml' path='types/type[@name="Icod.Threading.ISynchronousLock"]/member[@name="Enter"]/*'/>
		public void Enter() {
			this.EnterExclusive();
		}
		/// <include file='..\..\doc\Icod.Threading.xml' path='types/type[@name="Icod.Threading.ISynchronousLock"]/member[@name="Exit"]/*'/>
		public void Exit() {
			this.ExitExclusive();
		}

		private void EnterExclusive() {
			this.IncExcluder();
			do {
				_ = myShareLock.Reset();
#if NET8_0_OR_GREATER
				System.ObjectDisposedException.ThrowIf( !myExcludeLock.WaitOne(), null );
#else
				if ( !myExcludeLock.WaitOne() ) {
					throw new System.ObjectDisposedException( null );
				}
#endif
			} while ( 0 != ( Icod.Threading.SharedLock.ShareMask & theReader( ref this.State ) ) );
		}

		private void ExitExclusive() {
			_ = myExcludeLock.Set();
			System.Int32 waitingShares = this.DecExcluder();
			if ( 0 < waitingShares ) {
				_ = myWaitLock.Release( waitingShares );
			}
			if ( Icod.Threading.SharedLock.ExcludeBit != ( Icod.Threading.SharedLock.ExcludeBit & theReader( ref this.State ) ) ) {
				_ = myShareLock.Set();
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
#if NET8_0_OR_GREATER
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
#if NET8_0_OR_GREATER
			System.ArgumentNullException.ThrowIfNull( result, nameof( result ) );
#else
			if ( null == result ) {
				throw new System.ArgumentNullException( nameof( result ) );
			}
#endif
			Icod.Threading.LockResult input = ( result as Icod.Threading.LockResult ) ?? throw new System.ArgumentNullException( nameof( result ) );
			return input.End();
		}
		#endregion APM

		private void IncExcluder() {
			System.Int32 current;
			System.Int32 desired;
			do {
				_ = myShareLock.Reset(); // blocks any future shares until we are done excluding
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
			_ = myExcludeLock.Reset();
			// if there are no excluders, then we can immediately share;
			// otherwise, we are enqueuing a waitingsharer
			do {
				if ( Icod.Threading.SharedLock.ExcludeBit == ( Icod.Threading.SharedLock.ExcludeBit & theReader( ref this.State ) ) ) {
					this.IncWaitingSharer();
#if NET8_0_OR_GREATER
					System.ObjectDisposedException.ThrowIf( !myWaitLock.WaitOne(), null );
#else
					if ( !myWaitLock.WaitOne() ) {
						throw new System.ObjectDisposedException( null );
					}
#endif
					this.DecWaitingSharer();
				}
				if ( Icod.Threading.SharedLock.ExcludeBit != ( Icod.Threading.SharedLock.ExcludeBit & theReader( ref this.State ) ) ) {
					this.IncSharer();
#if NET8_0_OR_GREATER
					System.ObjectDisposedException.ThrowIf( !myShareLock.WaitOne(), null );
#else
					if ( !myShareLock.WaitOne() ) {
						throw new System.ObjectDisposedException( null );
					}
#endif
					break;
				}
			} while ( true );
		}
		private void ExitShare() {
			if ( 0 == this.DecSharer() ) {
				System.Int32 waiters = ( SharedLock.WaitingShareMask & theReader( ref this.State ) ) >> SharedLock.WaitingShareOffset;
				if ( 0 < waiters ) {
					_ = this.myWaitLock.Release( waiters );
				}
			}
			if ( 0 == ( SharedLock.ShareMask & theReader( ref this.State ) ) ) {
				_ = myExcludeLock.Set();
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
#if NET8_0_OR_GREATER
			System.ArgumentNullException.ThrowIfNull( asyncResult, nameof( asyncResult ) );
#else
			if ( null == asyncResult ) {
				throw new System.ArgumentNullException( nameof( asyncResult ) );
			}
#endif
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
#if NET8_0_OR_GREATER
			System.ArgumentNullException.ThrowIfNull( result, nameof( result ) );
#else
			if ( null == result ) {
				throw new System.ArgumentNullException( nameof( result ) );
			}
#endif
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
		/// <include file='..\..\doc\Icod.Threading.xml' path='types/type[@name="System.IDisposable"]/member[@name="Dispose"]/*'/>
		public void Dispose() {
			this.Dispose( true );
			System.GC.SuppressFinalize( this );
		}
		/// <include file='..\..\doc\Icod.Threading.xml' path='types/type[@name="System.IDisposable"]/member[@name="Dispose(System.Boolean)"]/*'/>
		private void Dispose( System.Boolean disposing ) {
			if ( true == disposing ) {
				System.Threading.Thread.BeginCriticalRegion();
				if ( !myIsDisposed ) {
					myWaitLock?.Close();
					myShareLock?.Close();
					myExcludeLock?.Close();
				}
				myIsDisposed = true;
				System.Threading.Thread.EndCriticalRegion();
			}
		}
		#endregion dispose
		#endregion methods

	}

}