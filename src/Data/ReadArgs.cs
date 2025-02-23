namespace Icod.Data { 

	/// <include file='..\..\doc\Icod.Data.xml' path='types/type[@name="Icod.Data.ReadEventArgs`1"]/member[@name=""]/*'/>
	[Icod.Author( "Timothy J. ``Flytrap\'\' Bruce" )]
	[Icod.ReportBugsTo( "mailto:uniblab@hotmail.com" )]
	[Icod.LgplLicense]
	public class ReadEventArgs<T> : System.EventArgs { 

		#region fields
		private System.Data.Common.DbCommand myCommand;
		private System.Boolean myCancel;
		private T myItem;
		#endregion fields


		#region .ctor
		/// <include file='..\..\doc\Icod.Data.xml' path='types/type[@name="Icod.Data.ReadEventArgs`1"]/member[@name="#ctor"]/*'/>
		internal ReadEventArgs() : base() { 
			this.Command = null;
			this.Cancel = true;
		}

		/// <include file='..\..\doc\Icod.Data.xml' path='types/type[@name="Icod.Data.ReadEventArgs`1"]/member[@name="#ctor(`0)"]/*'/>
		internal ReadEventArgs( T item ) : this() { 
			this.Item = item;
		}
		#endregion .ctor


		#region properties
		/// <include file='..\..\doc\Icod.Data.xml' path='types/type[@name="Icod.Data.ReadEventArgs`1"]/member[@name="Cancel"]/*'/>
		public System.Boolean Cancel { 
			get { 
				return myCancel;
			}
			set { 
				myCancel = value;
			}
		}

		/// <include file='..\..\doc\Icod.Data.xml' path='types/type[@name="Icod.Data.ReadEventArgs`1"]/member[@name="Command"]/*'/>
		public System.Data.Common.DbCommand Command { 
			get { 
				return myCommand;
			}
			set { 
				myCommand = value;
			}
		}

		/// <include file='..\..\doc\Icod.Data.xml' path='types/type[@name="Icod.Data.ReadEventArgs`1"]/member[@name="Item"]/*'/>
		public T Item { 
			get { 
				return myItem;
			}
			set { 
				myItem = value;
			}
		}
		#endregion properties

	}

}