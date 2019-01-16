using Akka.Actor;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using WFLite.Activities;

namespace WFLite.Akka.Bases
{
    public abstract class ActorAsyncActivity : AsyncActivity
    {
        private readonly IActorContext _context;

        private readonly IActorRef _self;

        private readonly IActorRef _sender;

        public ActorAsyncActivity(IActorContext context, IActorRef self, IActorRef sender)
        {
            _context = context;
            _self = self;
            _sender = sender;
        }

        protected sealed override Task<bool> run(CancellationToken cancellationToken)
        {
            return run(_context, _self, _sender, cancellationToken);
        }

        protected abstract Task<bool> run(IActorContext context, IActorRef self, IActorRef sender, CancellationToken cancellationToken);
    }
}