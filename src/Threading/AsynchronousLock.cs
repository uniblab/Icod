namespace Icod.Threading { 

	/// <include file='..\..\doc\Icod.Threading.xml' path='types/type[@name="Icod.Threading.AsynchronousLock`1"]/member[@name=""]/*'/>
	[Icod.LgplLicense]
	[Icod.Author( "Timothy J. ``Flytrap'' Bruce" )]
	[Icod.ReportBugsTo( "mailto:uniblab@hotmail.com" )]
	public sealed class AsynchronousLock<L> : ISynchronousLock, IAsynchronousLock where L : class, ISynchronousLock, new() { 

		#region fields
		private Icod.Threading.ISynchronousLock myLock;
		#endregion fields


		#region .ctor
		/// <include file='..\..\doc\Icod.Threading.xml' path='types/type[@name="Icod.Threading.AsynchronousLock`1"]/member[@name="#ctor"]/*'/>
		public AsynchronousLock() : this( new L() ) { 
		}
		/// <include file='..\..\doc\Icod.Threading.xml' path='types/type[@name="Icod.Threading.AsynchronousLock`1"]/member[@name="#ctor(L)"]/*'/>
		public AsynchronousLock( L theLock ) : base() { 
			if ( null == theLock ) { 
				throw new System.ArgumentNullException( "theLock" );
			}
			myLock = theLock;
		}
		[System.Runtime.ConstrainedExecution.PrePrepareMethod]
		~AsynchronousLock() { 
			this.Dispose( false );
		}
		#endregion .ctor

 
		#region methods
		/// <include file='..\..\doc\Icod.Threading.xml' path='types/type[@name="Icod.Threading.ISynchronousLock"]/member[@name="Enter"]/*'/>
		public void Enter() { 
			if ( null == myLock ) { 
				throw new System.InvalidOperationException();
			}
			myLock.Enter();
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

		/// <include file='..\..\doc\Icod.Threading.xml' path='types/type[@name="Icod.Threading.IAsynchronousLock"]/member[@name="BeginAcquire"]/*'/>
		public System.IAsyncResult BeginAcquire( System.AsyncCallback callback, System.Object state ) { 
			Icod.Threading.LockResult output = new Icod.Threading.LockResult( callback, state );
			System.Threading.ThreadPool.QueueUserWorkItem( this.AcquireHelper, output );
			if ( output.IsCompleted ) { 
				output.SetSynchronousCopmpletion( true );
			}
			return output;
		}

		/// <include file='..\..\doc\Icod.Threading.xml' path='types/type[@name="Icod.Threading.IAsynchronousLock"]/member[@name="EndAcquire"]/*'/>
		public System.IDisposable EndAcquire( System.IAsyncResult result ) { 
			Icod.Threading.LockResult input = (Icod.Threading.LockResult)result;
			return input.End();
		}

		[System.Diagnostics.CodeAnalysis.SuppressMessage( 
			"Microsoft.Design", 
			"CA1031:DoNotCatchGeneralExceptionTypes", 
			Justification = "The exception *will* be rethrown when End* is invoked." 
		)]
		private void AcquireHelper( System.Object asyncResult ) { 
			Icod.Threading.LockResult input = (Icod.Threading.LockResult)asyncResult;
			try { 
				System.IDisposable result = this.Acquire();
				input.Complete( result, false, null );
			} catch ( System.Exception e ) { 
				input.Complete( false, e );
			}
		}

		[System.Runtime.ConstrainedExecution.PrePrepareMethod]
		public void Dispose() { 
			this.Dispose( true );
			System.GC.SuppressFinalize( this );
		}
		[System.Runtime.ConstrainedExecution.PrePrepareMethod]
		public void Dispose( System.Boolean disposing ) { 
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