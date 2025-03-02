namespace Icod.Data { 

	/// <include file='..\..\doc\Icod.Data.xml' path='types/type[@name="Icod.Data.DataEnumerable`1"]/member[@name=""]/*'/>
	[Icod.Author( "Timothy J. ``Flytrap\'\' Bruce" )]
	[Icod.ReportBugsTo( "mailto:uniblab@hotmail.com" )]
	[Icod.LgplLicense]
	public class DataEnumerable<T> : Icod.Data.DataStore<T>, Icod.Data.IDataEnumerable<T> where T : IDataReadable, new() { 

		#region fields
		#endregion fields


		#region events
		/// <include file='..\..\doc\Icod.Data.xml' path='types/type[@name="Icod.Data.DataEnumerable`1"]/member[@name="Enumerating"]/*'/>
		protected event EnumeratingEventHandler<IDataEnumerable<T>, ReadEventArgs<T>> Enumerating;
		#endregion events


		#region .ctor
		/// <include file='..\..\doc\Icod.Data.xml' path='types/type[@name="Icod.Data.DataEnumerable`1"]/member[@name="#ctor(System.Data.Common.DbConnection)"]/*'/>
		public DataEnumerable( System.Data.Common.DbConnection connection ) : base( connection ) { 
		}

		/// <include file='..\..\doc\Icod.Data.xml' path='types/type[@name="Icod.Data.DataEnumerable`1"]/member[@name="#ctor(System.Data.Common.DbConnection,System.Data.CommandBehavior)"]/*'/>
		public DataEnumerable( System.Data.Common.DbConnection connection, System.Data.CommandBehavior commandBehaviour ) : base( connection, commandBehaviour ) { 
		}

		/// <include file='..\..\doc\Icod.Data.xml' path='types/type[@name="Icod.Data.DataEnumerable`1"]/member[@name="#ctor"]/*'/>
		protected DataEnumerable() : base() { 
		}
		#endregion .ctor


		#region properties
		internal System.Data.Common.DbCommand EnumeratorDataSource { 
			get { 
				ReadEventArgs<T> arg = new ReadEventArgs<T>();
				this.Enumerating?.Invoke( this, arg );
				if ( true == arg.Cancel ) { 
					arg = null;
					return null;
				}
				arg.Command.Connection = this.DataConnection;
				return arg.Command;
			}
		}
		#endregion properties


		#region methods
		/// <include file='..\..\doc\Icod.Data.xml' path='types/type[@name="Icod.Data.IDataEnumerable`1"]/member[@name="GetEnumerator"]/*'/>
		public System.Collections.IEnumerator GetEnumerator() { 
			return new DataEnumerator<T>( this.EnumeratorDataSource, this.Behaviour );
		}

		/// <include file='..\..\doc\Icod.Data.xml' path='types/type[@name="Icod.Data.IDataEnumerable`1"]/member[@name="GetEnumerator"]/*'/>
		System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { 
			return new DataEnumerator<T>( this.EnumeratorDataSource, this.Behaviour );
		}

		/// <include file='..\..\doc\Icod.Data.xml' path='types/type[@name="Icod.Data.IDataEnumerable`1"]/member[@name="GetEnumerator"]/*'/>
		System.Collections.Generic.IEnumerator<T> System.Collections.Generic.IEnumerable<T>.GetEnumerator() { 
			return new DataEnumerator<T>( this.EnumeratorDataSource, this.Behaviour );
		}
		#endregion methods

	}

}