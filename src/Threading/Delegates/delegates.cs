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

	/// <include file='..\..\..\doc\Icod.Threading.xml' path='types/type[@name="Icod.Threading.LockExitHandler"]/member[@name=""]/*'/>
	[Icod.Author( "Timothy J. ``Flytrap\'\' Bruce" )]
	[Icod.ReportBugsTo( "mailto:uniblab@hotmail.com" )]
	[Icod.LgplLicense]
	internal delegate void LockExitHandler();

	[Icod.Author( "Timothy J. ``Flytrap\'\' Bruce" )]
	[Icod.ReportBugsTo( "mailto:uniblab@hotmail.com" )]
	[Icod.LgplLicense]
// some asshole changed the argument names in Volatile.Read and .Write between versions
#if NET8_0_OR_GREATER
	internal delegate System.Int32 VolatileRead( ref readonly System.Int32 location );
#elif NET5_0_OR_GREATER
	internal delegate System.Int32 VolatileRead( ref System.Int32 location );
#else
	internal delegate System.Int32 VolatileRead( ref System.Int32 address );
#endif

	[Icod.Author( "Timothy J. ``Flytrap\'\' Bruce" )]
	[Icod.ReportBugsTo( "mailto:uniblab@hotmail.com" )]
	[Icod.LgplLicense]
// some asshole changed the argument names in Volatile.Read and .Write between versions
#if NET8_0_OR_GREATER
	internal delegate void VolatileWrite( ref System.Int32 location, System.Int32 value );
#else
	internal delegate void VolatileWrite( ref System.Int32 address, System.Int32 value );
#endif
}