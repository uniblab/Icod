namespace Icod.Data { 

	/// <include file='..\..\..\doc\Icod.Data.xml' path='types/type[@name="Icod.Data.IDataEnumerable`1"]/member[@name=""]/*'/>
	[Icod.Author( "Timothy J. ``Flytrap\'\' Bruce" )]
	[Icod.ReportBugsTo( "mailto:uniblab@hotmail.com" )]
	[Icod.LgplLicense]
	public interface IDataEnumerable<T> : IDataStore<T>, System.Collections.Generic.IEnumerable<T> where T : IDataReadable, new() { 

	}

}