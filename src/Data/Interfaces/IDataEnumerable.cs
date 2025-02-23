namespace Icod.Data { 

	/// <include file='..\..\..\doc\Icod.Data.xml' path='types/type[@name="Icod.Data.IDataEnumerable`1"]/member[@name=""]/*'/>
	[Icod.Author( "Timothy J. ``Flytrap\'\' Bruce" )]
	[Icod.ReportBugsTo( "mailto:uniblab@hotmail.com" )]
	[Icod.LgplLicense]
	[System.Diagnostics.CodeAnalysis.SuppressMessage( "Microsoft.Naming", 
		"CA1710:IdentifiersShouldHaveCorrectSuffix", 
		Justification = "This *is* the most specific (and correct) suffix" 
	)]
	public interface IDataEnumerable<T> : IDataStore<T>, System.Collections.Generic.IEnumerable<T> where T : IDataReadable, new() { 

	}

}