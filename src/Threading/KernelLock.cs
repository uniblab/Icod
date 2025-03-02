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
				if ( Icod.Threading.Interlocked.ExchangeCompare( ref this.State, oldState, oldState + Icod.Threading.KernelLock.Waiter ) ) { 
					_ = waitKLock.WaitOne();
				}
			}
		}

		/// <include file='..\..\doc\Icod.Threading.xml' path='types/type[@name="Icod.Threading.ISynchronousLock"]/member[@name="Exit"]/*'/>
		public sealed override void Exit() { 
			System.Int32 oldState = Icod.Threading.Interlocked.And( ref this.State, ~Icod.Threading.KernelLock.Owner );
			if ( oldState != Icod.Threading.KernelLock.Owner ) { 
				oldState &= ~Icod.Threading.KernelLock.Owner;
				if ( Icod.Threading.Interlocked.ExchangeCompare( ref this.State, oldState & ~Icod.Threading.KernelLock.Owner, oldState - Icod.Threading.KernelLock.Waiter ) ) { 
					_ = waitKLock.Release();
				}
			}
			System.Threading.Thread.EndCriticalRegion();
		}

		/// <include file='..\..\doc\Icod.Threading.xml' path='types/type[@name="System.IDisposable"]/member[@name="Dispose(System.Boolean)"]/*'/>
		protected sealed override void Dispose( System.Boolean disposing ) { 
			if ( disposing ) { 
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