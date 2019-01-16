using Akka.Actor;
using System;
using System.Collections.Generic;
using System.Text;
using WFLite.Bases;

namespace WFLite.Akka.Bases
{
    public abstract class ActorCondition : Condition
    {
        private readonly IActorContext _context;

        private readonly IActorRef _self;

        private readonly IActorRef _sender;

        public ActorCondition(IActorContext context, IActorRef self, IActorRef sender)
        {
            _context = context;
            _self = self;
            _sender = sender;
        }

        protected sealed override bool check()
        {
            return check(_context, _self, _sender);
        }

        protected abstract bool check(IActorContext context, IActorRef self, IActorRef sender);
    }
}
