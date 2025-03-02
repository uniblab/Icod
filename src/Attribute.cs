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
	public abstract class Attribute : System.Attribute, System.Runtime.Serialization.ISerializable { 

		/// <include file='..\doc\Icod.xml' path='types/type[@name="Icod.Attribute"]/member[@name="#ctor"]/*'/>
		protected Attribute() : base() { 
		}

		/// <include file='..\doc\Icod.xml' path='types/type[@name="Icod.Attribute"]/member[@name="#ctor(System.Runtime.Serialization.SerializationInfo,System.Runtime.Serialization.StreamingContext)"]/*'/>
		protected Attribute( System.Runtime.Serialization.SerializationInfo info, System.Runtime.Serialization.StreamingContext sc ) : this()  { 
		}

		/// <include file='..\doc\Icod.xml' path='types/type[@name="Icod.Attribute"]/member[@name="GetObjectData(System.Runtime.Serialization.SerializationInfo,System.Runtime.Serialization.StreamingContext)"]/*'/>
		public abstract void GetObjectData( System.Runtime.Serialization.SerializationInfo info, System.Runtime.Serialization.StreamingContext context );

	}

}