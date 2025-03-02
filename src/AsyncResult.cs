using Icod.Threading;

namespace Icod { 

	/// <include file='..\doc\Icod.xml' path='types/type[@name="Icod.AsyncResult"]/member[@name=""]/*'/>
	[Icod.LgplLicense]
	[Icod.Author( "Timothy J. ``Flytrap'' Bruce" )]
	[Icod.ReportBugsTo( "mailto:uniblab@hotmail.com" )]
	public abstract class AsyncResult : System.IAsyncResult { 

		#region fields
		private static readonly VolatileRead theReader;
		private static readonly VolatileWrite theWriter;

		private readonly System.AsyncCallback myCallback;
		private readonly System.Object myAsyncState;
		private System.Threading.ManualResetEvent myWaitHandle;

		private const System.Int32 PendingCompletion = 0;
		private const System.Int32 SynchronousloyCompleted = 1;
		private const System.Int32 AsynchronoyslyCompleted = 2;
		private System.Int32 myStatus;

		private System.Exception myCompletionException;
		#endregion fields


		#region .ctor
		static AsyncResult() {
// some asshole changed the argument names in Volatile.Read and .Write between versions
#if NET8_0_OR_GREATER
			theReader = System.Threading.Volatile.Read;
			theWriter = System.Threading.Volatile.Write;
#elif NET45_OR_GREATER || NETCOREAPP || NETSTANDARD || NET5_0_OR_GREATER
			theReader = System.Threading.Volatile.Read;
			theWriter = System.Threading.Volatile.Write;
#else
			theReader = System.Threading.Thread.VolatileRead;
			theWriter = System.Threading.Thread.VolatileWrite;
#endif
		}

		/// <include file='..\doc\Icod.xml' path='types/type[@name="Icod.AsyncResult"]/member[@name="#ctor(System.AsyncCallback,System.Object)"]/*'/>
		protected AsyncResult( System.AsyncCallback callback, System.Object asyncState ) { 
			myCallback = callback;
			myAsyncState = asyncState;
		}
#endregion .ctor


		#region properties
		/// <include file='..\doc\Icod.xml' path='types/type[@name="Icod.AsyncResult"]/member[@name="AsyncState"]/*'/>
		public System.Object AsyncState { 
			get { 
				return myAsyncState;
			}
		}

		/// <include file='..\doc\Icod.xml' path='types/type[@name="Icod.AsyncResult"]/member[@name="AsyncWaitHandle"]/*'/>
		public System.Threading.WaitHandle AsyncWaitHandle { 
			get { 
				if ( null == myWaitHandle ) { 
					System.Boolean isDone = this.IsCompleted;
					System.Threading.ManualResetEvent probe = new System.Threading.ManualResetEvent( isDone );
					if ( false == Icod.Threading.Interlocked.ExchangeCompare<System.Threading.ManualResetEvent>( ref myWaitHandle, null, probe ) ) { 
						probe.Close();
					} else { 
						if ( !isDone && this.IsCompleted ) { 
							_ = myWaitHandle.Set();
						}
					}
				}
				return myWaitHandle;
			}
		}

		/// <include file='..\doc\Icod.xml' path='types/type[@name="Icod.AsyncResult"]/member[@name="CompletedSynchronously"]/*'/>
		public System.Boolean CompletedSynchronously { 
			get { 
				return ( SynchronousloyCompleted == theReader( ref myStatus ) );
			}
		}

		/// <include file='..\doc\Icod.xml' path='types/type[@name="Icod.AsyncResult"]/member[@name="IsCompleted"]/*'/>
		public System.Boolean IsCompleted { 
			get { 
				return ( PendingCompletion != theReader( ref myStatus ) );
			}
		}
		#endregion properties


		#region methods
		/// <include file='..\doc\Icod.xml' path='types/type[@name="Icod.AsyncResult"]/member[@name="SetCompletedSynchronously(System.Boolean)"]/*'/>
		protected void SetCompletedSynchronously( System.Boolean value ) { 
			if ( false == this.IsCompleted ) { 
				throw new System.InvalidOperationException();
			}
			theWriter( ref myStatus, value ? SynchronousloyCompleted : AsynchronoyslyCompleted );
		}

		/// <include file='..\doc\Icod.xml' path='types/type[@name="Icod.AsyncResult"]/member[@name="SetCompletion(System.Boolean,System.Exception)"]/*'/>
		protected void SetCompletion( System.Boolean completedSynchronously, System.Exception completionException ) { 
			if ( false == Icod.Threading.Interlocked.ExchangeCompare( ref myStatus, PendingCompletion, completedSynchronously ? SynchronousloyCompleted : AsynchronoyslyCompleted ) ) { 
				throw new System.InvalidOperationException();
			}
			myCompletionException = completionException;
			_ = myWaitHandle?.Set();
			myCallback?.Invoke( this );
		}

		/// <include file='..\doc\Icod.xml' path='types/type[@name="Icod.AsyncResult"]/member[@name="EndInvoke"]/*'/>
		protected void EndInvoke() { 
			if ( false == this.IsCompleted ) { 
				_ = this.AsyncWaitHandle.WaitOne();
			}
			if ( null != myWaitHandle ) { 
				myWaitHandle.Close();
				myWaitHandle = null;
			}

			if ( null != myCompletionException ) { 
				throw myCompletionException;
			}
		}
		#endregion methods

	}

}