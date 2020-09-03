﻿using NHibernate;
using NHibernate.Mapping.ByCode.Conformist;

namespace DDD.Core.Infrastructure.Data
{
    using Core.Domain;

    public abstract class StoredEventMapping : ClassMapping<StoredEvent>
    {

        #region Constructors

        protected StoredEventMapping()
        {
            this.Lazy(false);
            // Table
            this.Table("Event");
            // Keys
            this.Id(e => e.Id, m1 =>  m1.Column("EventId"));
            // Fields
            this.Property(e => e.EventType, m =>
            {
                m.Type(NHibernateUtil.AnsiString);
                m.Length(50);
                m.NotNullable(true);
            });
            this.Property(e => e.StreamId, m =>
            {
                m.Type(NHibernateUtil.AnsiString);
                m.Length(50);
                m.NotNullable(true);
            });
            this.Property(e => e.CommitId, m => m.NotNullable(true));
            this.Property(e => e.OccurredOn, m => m.Precision(2));
            this.Property(e => e.Subject, m =>
            {
                m.Type(NHibernateUtil.AnsiString);
                m.Length(100);
            });
            this.Property(e => e.Body, m => m.NotNullable(true));
            this.Property(e => e.Dispatched);
        }

        #endregion Constructors

    }
}