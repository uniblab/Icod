namespace Icod.Threading { 

	/// <include file='..\..\doc\Icod.Threading.xml' path='types/type[@name="Icod.Threading.Lock`1"]/member[@name=""]/*'/>
	[Icod.Author( "Timothy J. ``Flytrap\'\' Bruce" )]
	[Icod.ReportBugsTo( "mailto:uniblab@hotmail.com" )]
	[Icod.LgplLicense]
	public class Lock<L> : ISynchronousLock where L : class, ISynchronousLock, new() { 

		#region fields
		private L myLock;
		#endregion fields


		#region .ctor
		/// <include file='..\..\doc\Icod.Threading.xml' path='types/type[@name="Icod.Threading.Lock`1"]/member[@name="#ctor"]/*'/>
		public Lock() : this( new L() ) { 
		}

		/// <include file='..\..\doc\Icod.Threading.xml' path='types/type[@name="Icod.Threading.Lock`1"]/member[@name="#ctor(L)"]/*'/>
		public Lock( L theLock ) { 
			if ( null == theLock ) { 
				throw new System.ArgumentNullException( "theLock" );
			}
			myLock = theLock;
		}
		~Lock() { 
			this.Dispose( false );
		}
		#endregion .ctor


		#region methods
		/// <include file='..\..\doc\Icod.Threading.xml' path='types/type[@name="Icod.Threading.ISynchronousLock"]/member[@name="Enter"]/*'/>
		void ISynchronousLock.Enter() {
			this.Enter();
		}
		public void Enter() { 
			if ( null == myLock ) { 
				throw new System.InvalidOperationException();
			}
			myLock.Enter();
		}

		void ISynchronousLock.Exit() { 
			this.Exit();
		}
		/// <include file='..\..\doc\Icod.Threading.xml' path='types/type[@name="Icod.Threading.ISynchronousLock"]/member[@name="Exit"]/*'/>
		public void Exit() {
			if ( null == myLock ) {
				throw new System.InvalidOperationException();
			}
			myLock.Exit();
		}

		/// <include file='..\..\doc\Icod.Threading.xml' path='types/type[@name="Icod.Threading.Lock`1"]/member[@name="Acquire"]/*'/>
		public System.IDisposable Acquire() { 
			myLock.Enter();
			return new LockExit( myLock.Exit );
		}

		[System.Runtime.ConstrainedExecution.PrePrepareMethod]
		public void Dispose() { 
			this.Dispose( true );
			System.GC.SuppressFinalize( this );
		}
		[System.Runtime.ConstrainedExecution.PrePrepareMethod]
		protected void Dispose( System.Boolean disposing ) { 
			if ( true == disposing ) { 
				System.Threading.Thread.BeginCriticalRegion();
				if ( null != myLock ) { 
					myLock.Dispose();
					myLock = null;
				}
				System.Threading.Thread.EndCriticalRegion();
			}
		}
		#endregion methods

	}

}