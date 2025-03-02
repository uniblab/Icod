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

	/// <include file='..\..\..\doc\Icod.Threading.xml' path='types/type[@name="Icod.Threading.ISynchronousSharedLock"]/member[@name=""]/*'/>
	public interface ISynchronousSharedLock : ISynchronousLock { 

		/// <include file='..\..\..\doc\Icod.Threading.xml' path='types/type[@name="Icod.Threading.ISynchronousSharedLock"]/member[@name="Share"]/*'/>
		System.IDisposable Share();

		/// <include file='..\..\..\doc\Icod.Threading.xml' path='types/type[@name="Icod.Threading.ISynchronousSharedLock"]/member[@name="Exclude"]/*'/>
		System.IDisposable Exclude();

	}

}