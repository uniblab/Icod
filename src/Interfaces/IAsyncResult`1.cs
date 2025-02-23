namespace Icod { 

	[Icod.LgplLicense]
	[Icod.Author( "Timothy J. ``Flytrap'' Bruce" )]
	[Icod.ReportBugsTo( "mailto:uniblab@hotmail.com" )]
	public interface IAsyncResult<R> : System.IAsyncResult { 

		R Result { 
			get;
		}

	}

}