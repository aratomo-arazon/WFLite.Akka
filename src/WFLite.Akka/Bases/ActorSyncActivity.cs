using Akka.Actor;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using WFLite.Activities;

namespace WFLite.Akka.Bases
{
    public abstract class ActorSyncActivity : SyncActivity
    {
        private readonly IActorContext _context;

        private readonly IActorRef _self;

        private readonly IActorRef _sender;

        public ActorSyncActivity(IActorContext context, IActorRef self, IActorRef sender)
        {
            _context = context;
            _self = self;
            _sender = sender;
        }

        protected sealed override bool run()
        {
            return run(_context, _self, _sender);
        }

        protected abstract bool run(IActorContext context, IActorRef self, IActorRef sender);
    }
}