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

	/// <include file='..\..\doc\Icod.xml' path='types/type[@name="Icod.AuthorAttribute"]/member[@name=""]/*'/>
	[System.AttributeUsage( System.AttributeTargets.All, AllowMultiple = true )]
	[System.Serializable]
	[Icod.LgplLicense]
	public sealed class AuthorAttribute : Icod.Attribute { 

		private readonly System.String myName;

		/// <include file='..\..\doc\Icod.xml' path='types/type[@name="Icod.AuthorAttribute"]/member[@name="#ctor(System.String)"]/*'/>
		public AuthorAttribute( System.String name ) : base() { 
			myName = name;
		}

		/// <include file='..\..\doc\Icod.xml' path='types/type[@name="Icod.AuthorAttribute"]/member[@name="#ctor(System.Runtime.Serialization.SerializationInfo,System.Runtime.Serialization.StreamingContext)"]/*'/>
		private AuthorAttribute( System.Runtime.Serialization.SerializationInfo info, System.Runtime.Serialization.StreamingContext sc ) : base( info, sc ) { 
			myName = info.GetString( "myName" );
		}

		/// <include file='..\..\doc\Icod.xml' path='types/type[@name="Icod.AuthorAttribute"]/member[@name="GetObjectData(System.Runtime.Serialization.SerializationInfo,System.Runtime.Serialization.StreamingContext)"]/*'/>
		public override void GetObjectData( System.Runtime.Serialization.SerializationInfo info, System.Runtime.Serialization.StreamingContext context ) {
			info?.AddValue( "myName", myName, typeof( System.String ) );
		}

		/// <include file='..\..\doc\Icod.xml' path='types/type[@name="Icod.AuthorAttribute"]/member[@name="Name"]/*'/>
		public System.String Name { 
			get { 
				return myName;
			}
		}

		/// <include file='..\..\doc\Icod.xml' path='types/type[@name="Icod.AuthorAttribute"]/member[@name="ToString"]/*'/>
		public override System.String ToString() { 
			return this.Name;
		}


	}

}
