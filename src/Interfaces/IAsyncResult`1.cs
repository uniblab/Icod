namespace Icod {

	///<include file='../doc/Icod.xml' path='types/type[@name="Icod.IAsyncResult`1"]/member[@name=""]/*'/>
	[Icod.LgplLicense]
	[Icod.Author( "Timothy J. ``Flytrap'' Bruce" )]
	[Icod.ReportBugsTo( "mailto:uniblab@hotmail.com" )]
	public interface IAsyncResult<R> : System.IAsyncResult {

		///<include file='../doc/Icod.xml' path='types/type[@name="Icod.IAsyncResult`1"]/member[@name="Result"]/*'/>
		R Result { 
			get;
		}

	}

}