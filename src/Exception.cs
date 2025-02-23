namespace Icod { 

	///<include file='..\doc\Icod.xml' path='types/type[@name="Icod.Exception"]/member[@name=""]/*'/>
	[Icod.LgplLicense]
	[Icod.Author( "Timothy J. ``Flytrap'' Bruce" )]
	[Icod.ReportBugsTo( "mailto:uniblab@hotmail.com" )]
	[System.Serializable]
	[System.Diagnostics.CodeAnalysis.SuppressMessage( "Microsoft.Design", 
		"CA1058:TypesShouldNotExtendCertainBaseTypes", 
		Justification = "We will continue basing our exception on System.ApplicationException, thank you very much just the same." 
	)]
	public class Exception : System.ApplicationException { 

		///<include file='..\doc\Icod.xml' path='types/type[@name="Icod.Exception"]/member[@name="#ctor"]/*'/>
		public Exception() : base() { 
		}

		///<include file='..\doc\Icod.xml' path='types/type[@name="Icod.Exception"]/member[@name="#ctor(System.String)"]/*'/>
		public Exception( System.String message ) : base(message) { 
		}

		///<include file='..\doc\Icod.xml' path='types/type[@name="Icod.Exception"]/member[@name="#ctor(System.String,System.Exception)"]/*'/>
		public Exception( System.String message, System.Exception innerException ) : base(message, innerException) { 
		}

		///<include file='..\doc\Icod.xml' path='types/type[@name="Icod.Exception"]/member[@name="#ctor(System.Runtime.Serialization.SerializationInfo,System.Runtime.Serialization.StreamingContext)"]/*'/>
		protected Exception( System.Runtime.Serialization.SerializationInfo info, System.Runtime.Serialization.StreamingContext sc ) : base(info, sc) { 
		}

	}

}