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

	/// <include file='..\doc\Icod.xml' path='types/type[@name="Icod.Attribute"]/member[@name=""]/*'/>
	[System.Serializable]
	[System.Diagnostics.CodeAnalysis.SuppressMessage( "Microsoft.Design", 
		"CA1019:DefineAccessorsForAttributeArguments", 
		Justification = "no such field is necessary" 
	)]
	public abstract class Attribute : System.Attribute, System.Runtime.Serialization.ISerializable { 

		/// <include file='..\doc\Icod.xml' path='types/type[@name="Icod.Attribute"]/member[@name="#ctor"]/*'/>
		protected Attribute() : base() { 
		}

		/// <include file='..\doc\Icod.xml' path='types/type[@name="Icod.Attribute"]/member[@name="#ctor(System.Runtime.Serialization.SerializationInfo,System.Runtime.Serialization.StreamingContext)"]/*'/>
		[System.Diagnostics.CodeAnalysis.SuppressMessage( "Microsoft.Performance", 
			"CA1801:AvoidUnusedParameters", 
			Justification = "this exists to support the serialization chain" 
		)]
		[System.Diagnostics.CodeAnalysis.SuppressMessage( "Microsoft.Performance", 
			"CA1801:AvoidUnusedParameters", 
			Justification = "this exists to support the serialization chain" 
		)]
		protected Attribute( System.Runtime.Serialization.SerializationInfo info, System.Runtime.Serialization.StreamingContext sc ) : this()  { 
		}

		/// <include file='..\doc\Icod.xml' path='types/type[@name="Icod.Attribute"]/member[@name="GetObjectData(System.Runtime.Serialization.SerializationInfo,System.Runtime.Serialization.StreamingContext)"]/*'/>
		[System.Security.Permissions.SecurityPermissionAttribute( 
			System.Security.Permissions.SecurityAction.LinkDemand, 
			Flags=System.Security.Permissions.SecurityPermissionFlag.SerializationFormatter 
		)]
		public abstract void GetObjectData( System.Runtime.Serialization.SerializationInfo info, System.Runtime.Serialization.StreamingContext context );

	}

}