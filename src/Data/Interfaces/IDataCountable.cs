namespace Icod.Data { 

	/// <include file='..\..\..\doc\Icod.Data.xml' path='types/type[@name="Icod.Data.IDataCountable`1"]/member[@name=""]/*'/>
	[Icod.Author( "Timothy J. ``Flytrap\'\' Bruce" )]
	[Icod.ReportBugsTo( "mailto:uniblab@hotmail.com" )]
	[Icod.LgplLicense]
	public interface IDataCountable<T> { 

		/// <include file='..\..\..\doc\Icod.Data.xml' path='types/type[@name="Icod.Data.IDataCountable`1"]/member[@name="Count"]/*'/>
		System.Int32 Count { 
			get;
		}

	}

}