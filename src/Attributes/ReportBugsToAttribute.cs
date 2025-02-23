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

	/// <include file='..\..\doc\Icod.xml' path='types/type[@name="Icod.ReportBugsToAttribute"]/member[@name=""]/*'/>
	[System.AttributeUsageAttribute( System.AttributeTargets.All, AllowMultiple = true )]
	[System.SerializableAttribute]
	[System.Diagnostics.CodeAnalysis.SuppressMessage( "Microsoft.Design", 
		"CA1019:DefineAccessorsForAttributeArguments", 
		Justification = "There is already a readonly field and a readonly property accessor" 
	)]
	[Icod.LgplLicense]
	public sealed class ReportBugsToAttribute : Icod.Attribute { 

		private readonly System.Uri myUri;

		/// <include file='..\..\doc\Icod.xml' path='types/type[@name="Icod.ReportBugsToAttribute"]/member[@name="#ctor(System.String)"]/*'/>
		public ReportBugsToAttribute( System.String uri ) : this( new System.Uri( uri ) ) { 
		}

		/// <include file='..\..\doc\Icod.xml' path='types/type[@name="Icod.ReportBugsToAttribute"]/member[@name="#ctor(System.Uri)"]/*'/>
		public ReportBugsToAttribute( System.Uri uri ) : base() { 
			myUri = uri;
		}

		/// <include file='..\..\doc\Icod.xml' path='types/type[@name="Icod.ReportBugsToAttribute"]/member[@name="#ctor(System.Runtime.Serialization.SerializationInfo,System.Runtime.Serialization.StreamingContext)"]/*'/>
		private ReportBugsToAttribute( System.Runtime.Serialization.SerializationInfo info, System.Runtime.Serialization.StreamingContext sc ) : base( info, sc ) { 
			myUri = (System.Uri)info.GetValue( "myUri", typeof( System.Uri ) );
		}

		/// <include file='..\..\doc\Icod.xml' path='types/type[@name="Icod.AuthorAttribute"]/member[@name="GetObjectData(System.Runtime.Serialization.SerializationInfo,System.Runtime.Serialization.StreamingContext)"]/*'/>
		[System.Security.Permissions.SecurityPermissionAttribute( 
			System.Security.Permissions.SecurityAction.LinkDemand, 
			Flags=System.Security.Permissions.SecurityPermissionFlag.SerializationFormatter 
		)]
		public override void GetObjectData( System.Runtime.Serialization.SerializationInfo info, System.Runtime.Serialization.StreamingContext context ) { 
			if ( null != info ) { 
				info.AddValue( "myUri", myUri, typeof( System.Uri ) );
			}
		}

		/// <include file='..\..\doc\Icod.xml' path='types/type[@name="Icod.ReportBugsToAttribute"]/member[@name="Uri"]/*'/>
		public System.Uri Uri { 
			get { 
				return myUri;
			}
		}

		/// <include file='..\..\doc\Icod.xml' path='types/type[@name="Icod.ReportBugsToAttribute"]/member[@name="ToString"]/*'/>
		public override System.String ToString() { 
			return this.Uri.ToString();
		}

	}

}
