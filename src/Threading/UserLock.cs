namespace Icod.Threading { 

	/// <include file='..\..\doc\Icod.Threading.xml' path='types/type[@name="Icod.Threading.UserLock"]/member[@name=""]/*'/>
	[Icod.LgplLicense]
	[Icod.Author( "Timothy J. ``Flytrap'' Bruce" )]
	[Icod.ReportBugsTo( "mailto:uniblab@hotmail.com" )]
	public sealed class UserLock : Icod.Threading.SynchronousLockBase {

		#region fields
		private static readonly VolatileRead theReader;

		private System.Int32 State;

		private const System.Int32 Free = 0;
		private const System.Int32 Owned = 1;
		#endregion fields


		#region .ctor
		static UserLock() {
#if NET8_0_OR_GREATER
			theReader = System.Threading.Volatile.Read;
#elif NET45_OR_GREATER || NETCOREAPP || NETSTANDARD || NET5_0_OR_GREATER
			theReader = System.Threading.Volatile.Read;
#else
			theReader = System.Threading.Thread.VolatileRead;
#endif
		}

		/// <include file='..\..\doc\Icod.Threading.xml' path='types/type[@name="Icod.Threading.UserLock"]/member[@name="#ctor"]/*'/>
		public UserLock() : base() { 
		}
		#endregion .ctor


		#region methods
		/// <include file='..\..\doc\Icod.Threading.xml' path='types/type[@name="Icod.Threading.ISynchronousLock"]/member[@name="Enter"]/*'/>
		public sealed override void Enter() { 
			System.Threading.Thread.BeginCriticalRegion();
			while ( true ) { 
				if ( Icod.Threading.UserLock.Free == System.Threading.Interlocked.Exchange( ref this.State, Icod.Threading.UserLock.Owned ) ) { 
					break;
				}
				while ( Icod.Threading.UserLock.Owned == theReader( ref this.State ) ) { 
					Icod.Threading.SynchronousLockBase.Spin();
				}
			}
		}

		/// <include file='..\..\doc\Icod.Threading.xml' path='types/type[@name="Icod.Threading.ISynchronousLock"]/member[@name="Exit"]/*'/>
		public sealed override void Exit() {
			_ = System.Threading.Interlocked.Exchange( ref this.State, Icod.Threading.UserLock.Free );
			System.Threading.Thread.EndCriticalRegion();
		}

		/// <include file='..\..\doc\Icod.Threading.xml' path='types/type[@name="Icod.Threading.SynchronousLockBase"]/member[@name="Dispose(System.Boolean)"]/*'/>
		protected sealed override void Dispose( System.Boolean disposing ) { 
			;
		}
		#endregion methods

	}

}