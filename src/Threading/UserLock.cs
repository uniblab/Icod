namespace Icod.Threading { 

	/// <include file='..\..\doc\Icod.Threading.xml' path='types/type[@name="Icod.Threading.UserLock"]/member[@name=""]/*'/>
	[Icod.LgplLicense]
	[Icod.Author( "Timothy J. ``Flytrap'' Bruce" )]
	[Icod.ReportBugsTo( "mailto:uniblab@hotmail.com" )]
	public sealed class UserLock : Icod.Threading.SynchronousLockBase { 

		#region fields
		private System.Int32 State;

		private const System.Int32 Free = 0;
		private const System.Int32 Owned = 1;
		#endregion fields


		#region .ctor
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
				while ( Icod.Threading.UserLock.Owned == System.Threading.Thread.VolatileRead( ref this.State ) ) { 
					Icod.Threading.SynchronousLockBase.Spin();
				}
			}
		}

		/// <include file='..\..\doc\Icod.Threading.xml' path='types/type[@name="Icod.Threading.ISynchronousLock"]/member[@name="Exit"]/*'/>
		public sealed override void Exit() { 
			System.Threading.Interlocked.Exchange( ref this.State, Icod.Threading.UserLock.Free );
			System.Threading.Thread.EndCriticalRegion();
		}

		/// <include file='..\..\doc\Icod.Threading.xml' path='types/type[@name="Icod.Threading.SynchronousLockBase"]/member[@name="Dispose(System.Boolean)"]/*'/>
		[System.Runtime.ConstrainedExecution.PrePrepareMethodAttribute()]
		protected sealed override void Dispose( System.Boolean disposing ) { 
			;
		}
		#endregion methods

	}

}