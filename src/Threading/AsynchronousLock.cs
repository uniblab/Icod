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

	/// <include file='..\..\doc\Icod.Threading.xml' path='types/type[@name="Icod.Threading.AsynchronousLock`1"]/member[@name=""]/*'/>
	[Icod.LgplLicense]
	[Icod.Author( "Timothy J. ``Flytrap'' Bruce" )]
	[Icod.ReportBugsTo( "mailto:uniblab@hotmail.com" )]
	public sealed class AsynchronousLock<L> : ISynchronousLock, IAsynchronousLock where L : class, ISynchronousLock, new() { 

		#region fields
		private readonly Icod.Threading.ISynchronousLock myLock;
		private System.Boolean myIsDisposed = false;
		#endregion fields


		#region .ctor
		/// <include file='..\..\doc\Icod.Threading.xml' path='types/type[@name="Icod.Threading.AsynchronousLock`1"]/member[@name="#ctor"]/*'/>
		public AsynchronousLock() : this( new L() ) { 
		}
		/// <include file='..\..\doc\Icod.Threading.xml' path='types/type[@name="Icod.Threading.AsynchronousLock`1"]/member[@name="#ctor(L)"]/*'/>
		public AsynchronousLock( L theLock ) : base() { 
			myLock = theLock ?? throw new System.ArgumentNullException( nameof( theLock ) );
		}
		/// <include file='..\..\doc\Icod.Threading.xml' path='types/type[@name="Icod.Threading.AsynchronousLock`1"]/member[@name="#dtor"]/*'/>
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
			_ = System.Threading.ThreadPool.QueueUserWorkItem( this.AcquireHelper, output );
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

		private void AcquireHelper( System.Object asyncResult ) { 
			Icod.Threading.LockResult input = (Icod.Threading.LockResult)asyncResult;
			try { 
				System.IDisposable result = this.Acquire();
				input.Complete( result, false, null );
			} catch ( System.Exception e ) { 
				input.Complete( false, e );
			}
		}

		/// <include file='..\..\doc\Icod.xml' path='types/type[@name="System.IDisposable"]/member[@name="Dispose"]/*'/>
		public void Dispose() { 
			this.Dispose( true );
			System.GC.SuppressFinalize( this );
		}
		/// <include file='..\..\doc\Icod.xml' path='types/type[@name="System.IDisposable"]/member[@name="Dispose(System.Boolean)"]/*'/>
		public void Dispose( System.Boolean disposing ) { 
			if ( disposing ) { 
				System.Threading.Thread.BeginCriticalRegion();
				if ( !myIsDisposed ) {
					myLock?.Dispose();
					myIsDisposed = true;
				}
				System.Threading.Thread.EndCriticalRegion();
			}
		}
		#endregion methods

	}

}