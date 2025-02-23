namespace Icod {

	///<include file='..\..\doc\Icod.xml' path='types/type[@name="Icod.ICloneable`1"]/member[@name=""]/*'/>
	[Icod.Author( "Timothy J. ``Flytrap'' Bruce" )]
	[Icod.ReportBugsTo( "mailto:uniblab@hotmail.com" )]
	[Icod.LgplLicense]
	public interface ICloneable<T> : System.ICloneable {

		new T Clone();

	}

}