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

	/// <include file='..\..\..\doc\Icod.xml' path='types/type[@name="Icod.GplLicenseAttribute"]/member[@name=""]/*'/>
	[System.AttributeUsage( System.AttributeTargets.All, AllowMultiple = true )]
	[System.Serializable]
	[System.Diagnostics.CodeAnalysis.SuppressMessage( "Microsoft.Design", 
		"CA1019:DefineAccessorsForAttributeArguments", 
		Justification = "no such field is necessary" 
	)]
	[System.Diagnostics.CodeAnalysis.SuppressMessage( "Microsoft.Design", 
		"CA1019:DefineAccessorsForAttributeArguments", 
		Justification = "no such field is necessary" 
	)]
	public sealed class GplLicenseAttribute : Icod.LicenseAttribute { 

		/// <summary>The actual license for this specific type.</summary>
		[System.NonSerialized]
		private const System.String theLicense = "Permission is hereby granted, free of charge, to any person obtaining"
			+ " a copy of this software and associated documentation files (the"
			+ " \"Software\"), to deal in the Software without restriction, including"
			+ " without limitation the rights to use, copy, modify, merge, publish,"
			+ " distribute, sublicense, and/or sell copies of the Software, and to"
			+ " permit persons to whom the Software is furnished to do so, subject to"
			+ " the following conditions:"
			+ "\r\n"
			+ "The above copyright notice and this permission notice shall be"
			+ " included in all copies or substantial portions of the Software."
			+ "\r\n"
			+ "THE SOFTWARE IS PROVIDED \"AS IS\", WITHOUT WARRANTY OF ANY KIND,"
			+ " EXPRESS OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF"
			+ " MERCHANTABILITY, FITNESS FOR A PARTICULAR PURPOSE AND"
			+ " NONINFRINGEMENT. IN NO EVENT SHALL THE AUTHORS OR COPYRIGHT HOLDERS BE"
			+ " LIABLE FOR ANY CLAIM, DAMAGES OR OTHER LIABILITY, WHETHER IN AN ACTION"
			+ " OF CONTRACT, TORT OR OTHERWISE, ARISING FROM, OUT OF OR IN CONNECTION"
			+ " WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN THE SOFTWARE."
		;

		/// <include file='..\..\..\doc\Icod.xml' path='types/type[@name="Icod.GplLicenseAttribute"]/member[@name="#ctor"]/*'/>
		public GplLicenseAttribute() : base( theLicense ) { 
		}

		/// <include file='..\..\..\doc\Icod.xml' path='types/type[@name="Icod.GplLicenseAttribute"]/member[@name="#ctor(System.Runtime.Serialization.SerializationInfo,System.Runtime.Serialization.StreamingContext)"]/*'/>
		private GplLicenseAttribute( System.Runtime.Serialization.SerializationInfo info, System.Runtime.Serialization.StreamingContext sc ) : base( info, sc ) { 
		}

	}

}
