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
