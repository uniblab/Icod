namespace Icod.Data { 

	/// <include file='..\..\..\doc\Icod.Data.xml' path='types/type[@name="Icod.Data.IDataExistential`1"]/member[@name=""]/*'/>
	[Icod.Author( "Timothy J. ``Flytrap\'\' Bruce" )]
	[Icod.ReportBugsTo( "mailto:uniblab@hotmail.com" )]
	[Icod.LgplLicense]
	public interface IDataExistential<T> { 

		/// <include file='..\..\..\doc\Icod.Data.xml' path='types/type[@name="Icod.Data.IDataExistential`1"]/member[@name="Contains(`0)"]/*'/>
		System.Boolean Contains( T item );

	}

}