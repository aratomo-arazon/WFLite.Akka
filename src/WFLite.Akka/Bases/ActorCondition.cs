/*
 * ActorCondition.cs
 *
 * Copyright (c) 2019 aratomo-arazon
 *
 * This software is released under the MIT License.
 * http://opensource.org/licenses/mit-license.php
 */
 
using Akka.Actor;
using Microsoft.Extensions.Logging;
using WFLite.Bases;
using WFLite.Logging.Bases;

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

    public abstract class ActorCondition<TCategoryName> : LoggingCondition<TCategoryName>
    {
        private readonly IActorContext _context;

        private readonly IActorRef _self;

        private readonly IActorRef _sender;

        public ActorCondition(ILogger<TCategoryName> logger, IActorContext context, IActorRef self, IActorRef sender)
            : base(logger)
        {
            _context = context;
            _self = self;
            _sender = sender;
        }

        protected sealed override bool check(ILogger<TCategoryName> logger)
        {
            return check(logger, _context, _self, _sender);
        }

        protected abstract bool check(ILogger<TCategoryName> logger, IActorContext context, IActorRef self, IActorRef sender);
    }
}
