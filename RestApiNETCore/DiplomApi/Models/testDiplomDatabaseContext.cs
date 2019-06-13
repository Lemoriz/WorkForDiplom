using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace DiplomApi.Models
{
    public partial class testDiplomDatabaseContext : DbContext
    {
        public testDiplomDatabaseContext()
        {
        }

        public testDiplomDatabaseContext(DbContextOptions<testDiplomDatabaseContext> options)
            : base(options)
        {
        }

        public virtual DbSet<AccessLevel> AccessLevel { get; set; }
        public virtual DbSet<Action> Action { get; set; }
        public virtual DbSet<ActionAuthorization> ActionAuthorization { get; set; }
        public virtual DbSet<ActionHistory> ActionHistory { get; set; }
        public virtual DbSet<ActionStatus> ActionStatus { get; set; }
        public virtual DbSet<Company> Company { get; set; }
        public virtual DbSet<Document> Document { get; set; }
        public virtual DbSet<DocumentType> DocumentType { get; set; }
        public virtual DbSet<Employee> Employee { get; set; }
        public virtual DbSet<EmployeeLogging> EmployeeLogging { get; set; }
        public virtual DbSet<Position> Position { get; set; }
        public virtual DbSet<SecurityInformation> SecurityInformation { get; set; }
        public virtual DbSet<Subdivision> Subdivision { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer(MetaInfo._connectionString);
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<AccessLevel>(entity =>
            {
                entity.Property(e => e.AccessLevelId).HasColumnName("AccessLevelID");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.ShortDescription)
                    .HasMaxLength(250)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Action>(entity =>
            {
                entity.Property(e => e.ActionId).HasColumnName("ActionID");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.ShortDescription)
                    .HasMaxLength(250)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<ActionAuthorization>(entity =>
            {
                entity.Property(e => e.ActionAuthorizationId).HasColumnName("ActionAuthorizationID");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.ShortDescription)
                    .HasMaxLength(250)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<ActionHistory>(entity =>
            {
                entity.Property(e => e.ActionHistoryId).HasColumnName("ActionHistoryID");

                entity.Property(e => e.ActionId).HasColumnName("ActionID");

                entity.Property(e => e.ActionStatusId).HasColumnName("ActionStatusID");

                entity.Property(e => e.Date)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.DocumentId).HasColumnName("DocumentID");

                entity.Property(e => e.EmployeeId).HasColumnName("EmployeeID");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.HasOne(d => d.Action)
                    .WithMany(p => p.ActionHistory)
                    .HasForeignKey(d => d.ActionId)
                    .HasConstraintName("FK_ActionHistory_ActionID");

                entity.HasOne(d => d.ActionStatus)
                    .WithMany(p => p.ActionHistory)
                    .HasForeignKey(d => d.ActionStatusId)
                    .HasConstraintName("FK_ActionHistory_ActionStatusID");

                entity.HasOne(d => d.Document)
                    .WithMany(p => p.ActionHistory)
                    .HasForeignKey(d => d.DocumentId)
                    .HasConstraintName("FK_ActionHistory_DocumentID");

                entity.HasOne(d => d.Employee)
                    .WithMany(p => p.ActionHistory)
                    .HasForeignKey(d => d.EmployeeId)
                    .HasConstraintName("FK_ActionHistory_EmployeeID");
            });

            modelBuilder.Entity<ActionStatus>(entity =>
            {
                entity.Property(e => e.ActionStatusId).HasColumnName("ActionStatusID");

                entity.Property(e => e.Name)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.ShortDescription)
                    .HasMaxLength(250)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Company>(entity =>
            {
                entity.Property(e => e.CompanyId).HasColumnName("CompanyID");

                entity.Property(e => e.Address)
                    .IsRequired()
                    .HasMaxLength(250)
                    .IsUnicode(false);

                entity.Property(e => e.ContactDetails)
                    .HasMaxLength(250)
                    .IsUnicode(false);

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.ShortName)
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Document>(entity =>
            {
                entity.Property(e => e.DocumentId).HasColumnName("DocumentID");

                entity.Property(e => e.CreationDate)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.DocumentTypeId).HasColumnName("DocumentTypeID");

                entity.Property(e => e.Hash)
                    .HasMaxLength(150)
                    .IsUnicode(false);

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.Path)
                    .IsRequired()
                    .HasMaxLength(250)
                    .IsUnicode(false);

                entity.Property(e => e.ShortDiscription)
                    .HasMaxLength(250)
                    .IsUnicode(false);

                entity.HasOne(d => d.DocumentType)
                    .WithMany(p => p.Document)
                    .HasForeignKey(d => d.DocumentTypeId)
                    .HasConstraintName("FK_Document_DocumentTypeID");
            });

            modelBuilder.Entity<DocumentType>(entity =>
            {
                entity.Property(e => e.DocumentTypeId).HasColumnName("DocumentTypeID");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.ShortDescription)
                    .HasMaxLength(250)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Employee>(entity =>
            {
                entity.Property(e => e.EmployeeId).HasColumnName("EmployeeID");

                entity.Property(e => e.CompanyId).HasColumnName("CompanyID");

                entity.Property(e => e.Email)
                    .IsRequired()
                    .HasMaxLength(70)
                    .IsUnicode(false);

                entity.Property(e => e.MiddleName)
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.Password)
                    .IsRequired()
                    .HasMaxLength(70)
                    .IsUnicode(false);

                entity.Property(e => e.PositionId).HasColumnName("PositionID");

                entity.Property(e => e.SubdivisionId).HasColumnName("SubdivisionID");

                entity.Property(e => e.Surname)
                    .IsRequired()
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.Property(e => e.TelephoneNumber)
                    .HasMaxLength(25)
                    .IsUnicode(false);

                entity.HasOne(d => d.Company)
                    .WithMany(p => p.Employee)
                    .HasForeignKey(d => d.CompanyId)
                    .HasConstraintName("FK_Employee_CompanyID");

                entity.HasOne(d => d.Position)
                    .WithMany(p => p.Employee)
                    .HasForeignKey(d => d.PositionId)
                    .HasConstraintName("FK_Employee_PositionID");

                entity.HasOne(d => d.Subdivision)
                    .WithMany(p => p.Employee)
                    .HasForeignKey(d => d.SubdivisionId)
                    .HasConstraintName("FK_Employee_SubdivisionID");
            });

            modelBuilder.Entity<EmployeeLogging>(entity =>
            {
                entity.Property(e => e.EmployeeLoggingId).HasColumnName("EmployeeLoggingID");

                entity.Property(e => e.ActionAuthorizationId).HasColumnName("ActionAuthorizationID");

                entity.Property(e => e.Date)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.EmployeeId).HasColumnName("EmployeeID");

                entity.HasOne(d => d.ActionAuthorization)
                    .WithMany(p => p.EmployeeLogging)
                    .HasForeignKey(d => d.ActionAuthorizationId)
                    .HasConstraintName("FK_EmployeeLogging_ActionAuthorizationID");

                entity.HasOne(d => d.Employee)
                    .WithMany(p => p.EmployeeLogging)
                    .HasForeignKey(d => d.EmployeeId)
                    .HasConstraintName("FK_EmployeeLogging_EmployeeID");
            });

            modelBuilder.Entity<Position>(entity =>
            {
                entity.Property(e => e.PositionId).HasColumnName("PositionID");

                entity.Property(e => e.AccessLevelId).HasColumnName("AccessLevelID");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.Property(e => e.ShortDescription)
                    .HasMaxLength(250)
                    .IsUnicode(false);

                entity.Property(e => e.ShortName)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.HasOne(d => d.AccessLevel)
                    .WithMany(p => p.Position)
                    .HasForeignKey(d => d.AccessLevelId)
                    .HasConstraintName("FK_Position_AccessLevelID");
            });

            modelBuilder.Entity<SecurityInformation>(entity =>
            {
                entity.Property(e => e.SecurityInformationId).HasColumnName("SecurityInformationID");

                entity.Property(e => e.DocumentId).HasColumnName("DocumentID");

                entity.Property(e => e.Hash)
                    .IsRequired()
                    .HasMaxLength(150)
                    .IsUnicode(false);

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.ShortDescription)
                    .HasMaxLength(250)
                    .IsUnicode(false);

                entity.HasOne(d => d.Document)
                    .WithMany(p => p.SecurityInformation)
                    .HasForeignKey(d => d.DocumentId)
                    .HasConstraintName("FK_SecurityInformation_DocumentID");
            });

            modelBuilder.Entity<Subdivision>(entity =>
            {
                entity.Property(e => e.SubdivisionId).HasColumnName("SubdivisionID");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.ShortName)
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });
        }
    }
}
