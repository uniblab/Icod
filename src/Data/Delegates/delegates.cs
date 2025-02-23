namespace Icod.Data { 

	/// <include file='..\..\..\doc\Icod.Data.xml' path='types/type[@name="Icod.Data.AddingEventHandler"]/member[@name=""]/*'/>
	[Icod.Author( "Timothy J. ``Flytrap\'\' Bruce" )]
	[Icod.ReportBugsTo( "mailto:uniblab@hotmail.com" )]
	[Icod.LgplLicense]
	public delegate void AddingEventHandler<S, E>( S sender, E e );

	/// <include file='..\..\..\doc\Icod.Data.xml' path='types/type[@name="Icod.Data.AddedEventHandler"]/member[@name=""]/*'/>
	[Icod.Author( "Timothy J. ``Flytrap\'\' Bruce" )]
	[Icod.ReportBugsTo( "mailto:uniblab@hotmail.com" )]
	[Icod.LgplLicense]
	public delegate void AddedEventHandler<S, E>( S sender, E e );

	/// <include file='..\..\..\doc\Icod.Data.xml' path='types/type[@name="Icod.Data.ClearingEventHandler"]/member[@name=""]/*'/>
	[Icod.Author( "Timothy J. ``Flytrap\'\' Bruce" )]
	[Icod.ReportBugsTo( "mailto:uniblab@hotmail.com" )]
	[Icod.LgplLicense]
	public delegate void ClearingEventHandler<S, E>( S sender, E e );

	/// <include file='..\..\..\doc\Icod.Data.xml' path='types/type[@name="Icod.Data.ClearedEventHandler"]/member[@name=""]/*'/>
	[Icod.Author( "Timothy J. ``Flytrap\'\' Bruce" )]
	[Icod.ReportBugsTo( "mailto:uniblab@hotmail.com" )]
	[Icod.LgplLicense]
	public delegate void ClearedEventHandler<S, E>( S sender, E e );

	/// <include file='..\..\..\doc\Icod.Data.xml' path='types/type[@name="Icod.Data.ContainingEventHandler"]/member[@name=""]/*'/>
	[Icod.Author( "Timothy J. ``Flytrap\'\' Bruce" )]
	[Icod.ReportBugsTo( "mailto:uniblab@hotmail.com" )]
	[Icod.LgplLicense]
	public delegate void ContainingEventHandler<S, E>( S sender, E e );

	/// <include file='..\..\..\doc\Icod.Data.xml' path='types/type[@name="Icod.Data.ContainedEventHandler"]/member[@name=""]/*'/>
	[Icod.Author( "Timothy J. ``Flytrap\'\' Bruce" )]
	[Icod.ReportBugsTo( "mailto:uniblab@hotmail.com" )]
	[Icod.LgplLicense]
	public delegate void ContainedEventHandler<S, E>( S sender, E e );

	/// <include file='..\..\..\doc\Icod.Data.xml' path='types/type[@name="Icod.Data.CountingEventHandler"]/member[@name=""]/*'/>
	[Icod.Author( "Timothy J. ``Flytrap\'\' Bruce" )]
	[Icod.ReportBugsTo( "mailto:uniblab@hotmail.com" )]
	[Icod.LgplLicense]
	public delegate void CountingEventHandler<S, E>( S sender, E e );

	/// <include file='..\..\..\doc\Icod.Data.xml' path='types/type[@name="Icod.Data.CountedEventHandler"]/member[@name=""]/*'/>
	[Icod.Author( "Timothy J. ``Flytrap\'\' Bruce" )]
	[Icod.ReportBugsTo( "mailto:uniblab@hotmail.com" )]
	[Icod.LgplLicense]
	public delegate void CountedEventHandler<S, E>( S sender, E e );

	/// <include file='..\..\..\doc\Icod.Data.xml' path='types/type[@name="Icod.Data.EnumeratingEventHandler"]/member[@name=""]/*'/>
	[Icod.Author( "Timothy J. ``Flytrap\'\' Bruce" )]
	[Icod.ReportBugsTo( "mailto:uniblab@hotmail.com" )]
	[Icod.LgplLicense]
	public delegate void EnumeratingEventHandler<S, E>( S sender, E e );

	/// <include file='..\..\..\doc\Icod.Data.xml' path='types/type[@name="Icod.Data.RemovingEventHandler"]/member[@name=""]/*'/>
	[Icod.Author( "Timothy J. ``Flytrap\'\' Bruce" )]
	[Icod.ReportBugsTo( "mailto:uniblab@hotmail.com" )]
	[Icod.LgplLicense]
	public delegate void RemovingEventHandler<S, E>( S sender, E e );

	/// <include file='..\..\..\doc\Icod.Data.xml' path='types/type[@name="Icod.Data.RemovedEventHandler"]/member[@name=""]/*'/>
	[Icod.Author( "Timothy J. ``Flytrap\'\' Bruce" )]
	[Icod.ReportBugsTo( "mailto:uniblab@hotmail.com" )]
	[Icod.LgplLicense]
	public delegate void RemovedEventHandler<S, E>( S sender, E e );

}