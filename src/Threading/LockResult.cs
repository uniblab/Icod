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

	/// <include file='..\..\doc\Icod.Threading.xml' path='types/type[@name="Icod.Threading.LockResult"]/member[@name=""]/*'/>
	[Icod.LgplLicense]
	[Icod.Author( "Timothy J. ``Flytrap'' Bruce" )]
	[Icod.ReportBugsTo( "mailto:uniblab@hotmail.com" )]
	internal class LockResult : Icod.AsyncResult<System.IDisposable> { 

		#region .ctor
		/// <include file='..\..\doc\Icod.Threading.xml' path='types/type[@name="Icod.Threading.LockResult"]/member[@name="#ctor(System.AsyncCallback,System.Object)"]/*'/>
		internal LockResult( System.AsyncCallback callback, System.Object asyncState ) : base( callback, asyncState ) { 
		}
		#endregion .ctor


		#region methods
		internal void SetSynchronousCopmpletion( System.Boolean synchronous ) { 
			base.SetCompletedSynchronously( synchronous );
		}

		/// <include file='..\..\doc\Icod.Threading.xml' path='types/type[@name="Icod.Threading.LockResult"]/member[@name="SetCompletion(R,System.Boolean,System.Exception)"]/*'/>
		internal void Complete( System.IDisposable result, System.Boolean completedSynchronously, System.Exception completionException ) { 
			base.SetCompletion( result, completedSynchronously, completionException );
		}
		/// <include file='..\..\doc\Icod.Threading.xml' path='types/type[@name="Icod.Threading.LockResult"]/member[@name="SetCompletion(System.Boolean,System.Exception)"]/*'/>
		internal void Complete( System.Boolean completedSynchronously, System.Exception completionException ) { 
			base.SetCompletion( completedSynchronously, completionException );
		}

		/// <include file='..\..\doc\Icod.Threading.xml' path='types/type[@name="Icod.Threading.LockResult"]/member[@name="EndInvoke"]/*'/>
		internal System.IDisposable End() { 
			return base.EndInvoke();
		}
		#endregion methods

	}

}