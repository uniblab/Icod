namespace Icod.Data { 

	/// <include file='..\..\doc\Icod.Data.xml' path='types/type[@name="Icod.Data.WriteEventArgs`1"]/member[@name=""]/*'/>
	public class WriteEventArgs<T> : Icod.Data.ReadEventArgs<T> { 

		/// <include file='..\..\doc\Icod.Data.xml' path='types/type[@name="Icod.Data.WriteEventArgs`1"]/member[@name="#ctor"]/*'/>
		internal WriteEventArgs() : base() { 
		}

		/// <include file='..\..\doc\Icod.Data.xml' path='types/type[@name="Icod.Data.WriteEventArgs`1"]/member[@name="#ctor(`0)"]/*'/>
		internal WriteEventArgs( T item ) : base( item ) { 
		}

      }

}