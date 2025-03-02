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

namespace Icod { 

	/// <include file='..\doc\Icod.xml' path='types/type[@name="Icod.AsyncResult`1"]/member[@name=""]/*'/>
	[Icod.LgplLicense]
	[Icod.Author( "Timothy J. ``Flytrap'' Bruce" )]
	[Icod.ReportBugsTo( "mailto:uniblab@hotmail.com" )]
	public abstract class AsyncResult<R> : Icod.AsyncResult, Icod.IAsyncResult<R> { 

		#region fields
		private R myResult;
		#endregion fields


		#region .ctor
		/// <include file='..\doc\Icod.xml' path='types/type[@name="Icod.AsyncResult`1"]/member[@name="#ctor(System.AsyncCallback,System.Object)"]/*'/>
		protected AsyncResult( System.AsyncCallback callback, System.Object asyncState ) : base( callback, asyncState ) { 
		}
		#endregion .ctor


		#region properties
		/// <include file='..\doc\Icod.xml' path='types/type[@name="Icod.IAsyncResult`1"]/member[@name="Result"]/*'/>
		public R Result { 
		get { 
				return myResult;
			}
		}
		#endregion properties


		#region methods
		/// <include file='..\doc\Icod.xml' path='types/type[@name="Icod.AsyncResult`1"]/member[@name="SetCompletion(`0,System.Boolean,System.Exception)"]/*'/>
		protected void SetCompletion( R result, System.Boolean completedSynchronously, System.Exception completionException ) { 
			myResult = result;
			base.SetCompletion( completedSynchronously, completionException );
		}
		/// <include file='..\doc\Icod.xml' path='types/type[@name="Icod.AsyncResult`1"]/member[@name="EndInvoke"]/*'/>
		new protected R EndInvoke() { 
			base.EndInvoke();
			return myResult;
		}
		#endregion methods

	}

}