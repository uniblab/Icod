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

	/// <include file='..\..\..\doc\Icod.Threading.xml' path='types/type[@name="Icod.Threading.IAsynchronousSharedLock"]/member[@name=""]/*'/>
	[Icod.LgplLicense]
	[Icod.Author( "Timothy J. ``Flytrap'' Bruce" )]
	[Icod.ReportBugsTo( "mailto:uniblab@hotmail.com" )]
	public interface IAsynchronousSharedLock : ISynchronousSharedLock { 

		/// <include file='..\..\..\doc\Icod.Threading.xml' path='types/type[@name="Icod.Threading.IAsynchronousSharedLock"]/member[@name="BeginWrite(System.AsyncCallback,System.Object)"]/*'/>
		System.IAsyncResult BeginExclude( System.AsyncCallback callback, System.Object state );
		/// <include file='..\..\..\doc\Icod.Threading.xml' path='types/type[@name="Icod.Threading.IAsynchronousSharedLock"]/member[@name="EndWrite(System.IAsyncResult)"]/*'/>
		System.IDisposable EndExclude( System.IAsyncResult result );

		/// <include file='..\..\..\doc\Icod.Threading.xml' path='types/type[@name="Icod.Threading.IAsynchronousSharedLock"]/member[@name="BeginRead(System.AsyncCallback,System.Object)"]/*'/>
		System.IAsyncResult BeginShare( System.AsyncCallback callback, System.Object state );
		/// <include file='..\..\..\doc\Icod.Threading.xml' path='types/type[@name="Icod.Threading.IAsynchronousSharedLock"]/member[@name="EndRead(System.IAsyncResult)"]/*'/>
		System.IDisposable EndShare( System.IAsyncResult result );

	}

}