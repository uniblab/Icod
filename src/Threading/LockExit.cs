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

	/// <include file='..\..\doc\Icod.Threading.xml' path='types/type[@name="Icod.Threading.LockExit"]/member[@name=""]/*'/>
	[Icod.Author( "Timothy J. ``Flytrap\'\' Bruce" )]
	[Icod.ReportBugsTo( "mailto:uniblab@hotmail.com" )]
	[Icod.LgplLicense]
	internal sealed class LockExit : System.IDisposable { 

		#region fields
		private Icod.Threading.LockExitHandler myExit;
		#endregion fields


		#region .ctor
		/// <include file='..\..\doc\Icod.Threading.xml' path='types/type[@name="Icod.Threading.LockExit"]/member[@name="#ctor"]/*'/>
		public LockExit( Icod.Threading.LockExitHandler exit ) { 
			myExit = exit ?? throw new System.ArgumentNullException( nameof( exit ) );
			System.Runtime.CompilerServices.RuntimeHelpers.PrepareDelegate( myExit );
		}
		#endregion .ctor


		#region methods
		/// <include file='..\..\doc\Icod.Threading.xml' path='types/type[@name="Icod.Threading.ISynchronousLock"]/member[@name="Exit"]/*'/>
		public void Dispose() { 
			this.Dispose( true );
			System.GC.SuppressFinalize( this );
		}

		/// <include file='..\..\doc\Icod.Threading.xml' path='types/type[@name="Icod.Threading.ISynchronousLock"]/member[@name="Exit"]/*'/>
		private void Dispose( System.Boolean disposing ) { 
			if ( disposing ) { 
				System.Threading.Thread.BeginCriticalRegion();
				if ( null != myExit ) { 
					myExit();
					myExit = null;
				}
				System.Threading.Thread.EndCriticalRegion();
			}
		}
		#endregion methods

	}

}