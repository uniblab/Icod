/*
	copyright (c) 2025 Timothy J. ``Flytrap'' Bruce of the ICOD
	written by Timothy J. ``Flytrap'' Bruce
	uniblab@hotmail.com
*/
/*
This library is free software; you can redistribute it and/or
 modify it under the terms of the GNU Lesser General Public
 License as published by the Free Software Foundation; either
 version 2.1 of the License, or (at your option) any later version.  

This library is distributed in the hope that it will be useful,
 but WITHOUT ANY WARRANTY; without even the implied warranty of
 MERCHANTABILITY of FITNESS FOR A PARTICULAR PURPOSE.  See the GNU
 Lesser General Public License for more details.  

You should have received a copy of the GNU Lesser General Public
 License along with this library; if not, write to the Free Software
 Foundation, Inc., 51 Franklin Street, Fifth Floor, Boston, MA 02110-1301 USA
*/

namespace Icod { 

	/// <include file='..\..\..\doc\Icod.xml' path='types/type[@name="Icod.LgplLicenseAttribute"]/member[@name=""]/*'/>
	[System.AttributeUsageAttribute( System.AttributeTargets.All, AllowMultiple = true )]
	[System.Serializable]
	[System.Diagnostics.CodeAnalysis.SuppressMessage( "Microsoft.Design", 
		"CA1019:DefineAccessorsForAttributeArguments", 
		Justification = "no such field is necessary" 
	)]
	[System.Diagnostics.CodeAnalysis.SuppressMessage( "Microsoft.Design", 
		"CA1019:DefineAccessorsForAttributeArguments", 
		Justification = "no such field is necessary" 
	)]
	public sealed class LgplLicenseAttribute : Icod.LicenseAttribute { 

		[System.NonSerialized]
		private const System.String theLicense = "This library is free software; you can redistribute it and/or"
			+ " modify it under the terms of the GNU Lesser General Public"
			+ " License as published by the Free Software Foundation; either"
			+ " version 2.1 of the License, or (at your option) any later version.  "
			+ "\r\n"
			+ "This library is distributed in the hope that it will be useful,"
			+ " but WITHOUT ANY WARRANTY; without even the implied warranty of"
			+ " MERCHANTABILITY of FITNESS FOR A PARTICULAR PURPOSE.  See the GNU"
			+ " Lesser General Public License for more details.  "
			+ "\r\n"
			+ "You should have received a copy of the GNU Lesser General Public"
			+ " License along with this library; if not, write to the Free Software"
			+ " Foundation, Inc., 51 Franklin Street, Fifth Floor, Boston, MA 02110-1301 USA"
		;

		/// <include file='..\..\..\doc\Icod.xml' path='types/type[@name="Icod.LgplLicenseAttribute"]/member[@name="#ctor"]/*'/>
		public LgplLicenseAttribute() : base( theLicense ) { 
		}

		/// <include file='..\..\..\doc\Icod.xml' path='types/type[@name="Icod.GplLicenseAttribute"]/member[@name="#ctor(System.Runtime.Serialization.SerializationInfo,System.Runtime.Serialization.StreamingContext)"]/*'/>
		private LgplLicenseAttribute( System.Runtime.Serialization.SerializationInfo info, System.Runtime.Serialization.StreamingContext sc ) : base( info, sc ) { 
		}

	}

}
