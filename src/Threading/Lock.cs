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

	/// <include file='..\..\doc\Icod.Threading.xml' path='types/type[@name="Icod.Threading.Lock`1"]/member[@name=""]/*'/>
	[Icod.Author( "Timothy J. ``Flytrap\'\' Bruce" )]
	[Icod.ReportBugsTo( "mailto:uniblab@hotmail.com" )]
	[Icod.LgplLicense]
	public class Lock<L> : ISynchronousLock where L : class, ISynchronousLock, new() { 

		#region fields
		private System.Boolean myIsDisposed = false;
		private readonly L myLock;
		#endregion fields


		#region .ctor
		/// <include file='..\..\doc\Icod.Threading.xml' path='types/type[@name="Icod.Threading.Lock`1"]/member[@name="#ctor"]/*'/>
		public Lock() : this( new L() ) { 
		}

		/// <include file='..\..\doc\Icod.Threading.xml' path='types/type[@name="Icod.Threading.Lock`1"]/member[@name="#ctor(L)"]/*'/>
		public Lock( L theLock ) { 
			myLock = theLock ?? throw new System.ArgumentNullException( nameof( theLock ) );
		}
		/// <include file='..\..\doc\Icod.Threading.xml' path='types/type[@name="Icod.Threading.Lock`1"]/member[@name="#dtor"]/*'/>
		~Lock() { 
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

		/// <include file='..\..\doc\Icod.xml' path='types/type[@name="System.IDisposable"]/member[@name="Dispose"]/*'/>
		public void Dispose() { 
			this.Dispose( true );
			System.GC.SuppressFinalize( this );
		}
		/// <include file='..\..\doc\Icod.xml' path='types/type[@name="System.IDisposable"]/member[@name="Dispose(System.Boolean)"]/*'/>
		protected void Dispose( System.Boolean disposing ) { 
			if ( disposing ) { 
				System.Threading.Thread.BeginCriticalRegion();
				if ( !myIsDisposed ) {
					myLock?.Dispose();
				}
				myIsDisposed = true;
				System.Threading.Thread.EndCriticalRegion();
			}
		}
		#endregion methods

	}

}