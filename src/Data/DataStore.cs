namespace Icod.Data { 

	/// <include file='..\..\doc\Icod.Data.xml' path='types/type[@name="Icod.Data.DataStore`1"]/member[@name=""]/*'/>
	[Icod.Author( "Timothy J. ``Flytrap\'\' Bruce" )]
	[Icod.ReportBugsTo( "mailto:uniblab@hotmail.com" )]
	[Icod.LgplLicense]
	public class DataStore<T> : IDataStore<T> { 

		#region fields
		private System.Boolean myIsDisposed;
		private readonly System.Data.CommandBehavior myBehaviour;
		private readonly System.Data.Common.DbConnection myConnection;
		#endregion fields


		#region .ctor
		/// <include file='..\..\doc\Icod.Data.xml' path='types/type[@name="Icod.Data.DataStore`1"]/member[@name="#ctor(System.Data.Common.DbConnection)"]/*'/>
		public DataStore( System.Data.Common.DbConnection connection ) : this( connection, System.Data.CommandBehavior.SingleResult ) { 
		}

		/// <include file='..\..\doc\Icod.Data.xml' path='types/type[@name="Icod.Data.DataStore`1"]/member[@name="#ctor(System.Data.Common.DbConnection,System.Data.CommandBehavior)"]/*'/>
		public DataStore( System.Data.Common.DbConnection connection, System.Data.CommandBehavior commandBehaviour ) : this() {
			myConnection = connection;
			myBehaviour = commandBehaviour;
		}

		/// <include file='..\..\doc\Icod.Data.xml' path='types/type[@name="Icod.Data.DataStore`1"]/member[@name="#ctor"]/*'/>
		protected DataStore() { 
			myIsDisposed = false;
		}

		/// <include file='..\..\doc\Icod.Data.xml' path='types/type[@name="Icod.Data.DataStore`1"]/member[@name="Finalize"]/*'/>
		~DataStore() { 
			this.Dispose( false );
		}
		#endregion .ctor


		#region properties
		/// <include file='..\..\doc\Icod.Data.xml' path='types/type[@name="Icod.Data.IDataStore`1"]/member[@name="Behaviour"]/*'/>
		public System.Data.CommandBehavior Behaviour { 
			get { 
				return myBehaviour;
			}
		}

		/// <include file='..\..\doc\Icod.Data.xml' path='types/type[@name="Icod.Data.IDataStore`1"]/member[@name="DataConnection"]/*'/>
		public System.Data.Common.DbConnection DataConnection { 
			get { 
				return myConnection;
			}
		}
		#endregion properties


		#region methods
		/// <include file='..\..\doc\Icod.Data.xml' path='types/type[@name="System.IDisposable"]/member[@name="Dispose"]/*'/>
		public void Dispose() { 
			this.Dispose( true );
			System.GC.SuppressFinalize( this );
		}

		/// <include file='..\..\doc\Icod.Data.xml' path='types/type[@name="System.IDisposable"]/member[@name="Dispose(System.Boolean)"]/*'/>
		protected virtual void Dispose( System.Boolean disposing ) { 
			lock ( this ) { 
				if ( !myIsDisposed ) { 
					if ( 
						( null != this.DataConnection ) 
						&& ( System.Data.CommandBehavior.CloseConnection == ( this.Behaviour & System.Data.CommandBehavior.CloseConnection ) )
					) { 
						this.DataConnection.Dispose();
					}
					myIsDisposed = true;
				}
			}
		}
		#endregion methods


		#region operators
		#endregion operators

	}

}