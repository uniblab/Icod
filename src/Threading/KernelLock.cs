namespace Icod.Threading { 

	/// <include file='..\..\doc\Icod.Threading.xml' path='types/type[@name="Icod.Threading.KernelLock"]/member[@name=""]/*'/>
	[Icod.LgplLicense]
	[Icod.Author( "Timothy J. ``Flytrap'' Bruce" )]
	[Icod.ReportBugsTo( "mailto:uniblab@hotmail.com" )]
	public sealed class KernelLock : SynchronousLockBase { 

		#region fields
		private System.Threading.Semaphore waitKLock;
		private System.Int32 State;

		private const System.Int32 Free = 0;
		private const System.Int32 Owner = 1;
		private const System.Int32 Waiter = 2;
		#endregion fields


		#region .ctor
		/// <include file='..\..\doc\Icod.Threading.xml' path='types/type[@name="Icod.Threading.KernelLock"]/member[@name="#ctor"]/*'/>
		public KernelLock() : base() { 
			waitKLock = new System.Threading.Semaphore( 0, System.Int32.MaxValue );
		}
		#endregion .ctor


		#region methods
		/// <include file='..\..\doc\Icod.Threading.xml' path='types/type[@name="Icod.Threading.ISynchronousLock"]/member[@name="Enter"]/*'/>
		public sealed override void Enter() { 
			System.Threading.Thread.BeginCriticalRegion();
			System.Int32 oldState;
			while ( true ) { 
				oldState = Icod.Threading.Interlocked.Or( ref this.State, Icod.Threading.KernelLock.Owner );
				if ( Icod.Threading.KernelLock.Free == ( oldState & Icod.Threading.KernelLock.Owner ) ) { 
					break;
				}
				if ( true == Icod.Threading.Interlocked.ExchangeCompare( ref this.State, oldState, oldState + Icod.Threading.KernelLock.Waiter ) ) { 
					waitKLock.WaitOne();
				}
			}
		}

		/// <include file='..\..\doc\Icod.Threading.xml' path='types/type[@name="Icod.Threading.ISynchronousLock"]/member[@name="Exit"]/*'/>
		public sealed override void Exit() { 
			System.Int32 oldState = Icod.Threading.Interlocked.And( ref this.State, ~Icod.Threading.KernelLock.Owner );
			if ( oldState != Icod.Threading.KernelLock.Owner ) { 
				oldState = oldState & ~Icod.Threading.KernelLock.Owner;
				if ( true == Icod.Threading.Interlocked.ExchangeCompare( ref this.State, oldState & ~Icod.Threading.KernelLock.Owner, oldState - Icod.Threading.KernelLock.Waiter ) ) { 
					waitKLock.Release();
				}
			}
			System.Threading.Thread.EndCriticalRegion();
		}

		/// <include file='..\..\doc\Icod.Threading.xml' path='types/type[@name="Icod.Threading.SynchronousLockBase"]/member[@name="Dispose(System.Boolean)"]/*'/>
		[System.Runtime.ConstrainedExecution.PrePrepareMethodAttribute()]
		protected sealed override void Dispose( System.Boolean disposing ) { 
			if ( true == disposing ) { 
				System.Threading.Thread.BeginCriticalRegion();
				if ( null != waitKLock ) { 
					waitKLock.Close();
					waitKLock = null;
				}
				System.Threading.Thread.EndCriticalRegion();
			}
		}
		#endregion methods

	}

}