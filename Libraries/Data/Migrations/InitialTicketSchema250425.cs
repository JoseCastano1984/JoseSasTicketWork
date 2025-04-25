using FluentMigrator;

namespace Data.Migrations;


    [Migration(1, "Creating Ticket Table")]
    public class InitialTicketSchema250425 : ForwardOnlyMigration
    {
        public override void Up()
        {
            if (!Schema.Table("Ticket").Exists())
            {
                Execute.Sql(@"CREATE TABLE [dbo].[Ticket](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[TicketNumber] [int] NOT NULL,
	[TicketName] [nvarchar](255) NOT NULL,
	[DateOfTicket] [datetime] NOT NULL,
	[TicketDescription] [nvarchar](max) NOT NULL,
	[IsFrontend] [bit] NOT NULL,
	[IsBackend] [bit] NOT NULL,
	[IsFullStack] [bit] NOT NULL,
 CONSTRAINT [PK_Ticket] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]");    
            }
        
        }
    }

