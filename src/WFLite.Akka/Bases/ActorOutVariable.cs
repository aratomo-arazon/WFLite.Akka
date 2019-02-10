/*
 * ActorOutVariable.cs
 *
 * Copyright (c) 2019 aratomo-arazon
 *
 * This software is released under the MIT License.
 * http://opensource.org/licenses/mit-license.php
 */
 
using Akka.Actor;
using Microsoft.Extensions.Logging;
using WFLite.Bases;
using WFLite.Interfaces;
using WFLite.Logging.Bases;

namespace WFLite.Akka.Bases
{
    public abstract class ActorOutVariable : LoggingOutVariable
    {
        private readonly IActorContext _context;

        private readonly IActorRef _self;

        private readonly IActorRef _sender;

        public ActorOutVariable(IActorContext context, IActorRef self, IActorRef sender, IConverter converter = null)
            : base(converter)
        {
            _context = context;
            _self = self;
            _sender = sender;
        }

        public ActorOutVariable(ILogger logger, IActorContext context, IActorRef self, IActorRef sender, IConverter converter = null)
            : base(logger, converter)
        {
            _context = context;
            _self = self;
            _sender = sender;
        }

        protected sealed override object getValue()
        {
            return getValue(_context, _self, _sender);
        }

        protected abstract object getValue(IActorContext context, IActorRef self, IActorRef sender);
    }

    public abstract class ActorOutVariable<TValue> : LoggingOutVariable<TValue>
    {
        private readonly IActorContext _context;

        private readonly IActorRef _self;

        private readonly IActorRef _sender;

        public ActorOutVariable(IActorContext context, IActorRef self, IActorRef sender, IConverter<TValue> converter = null)
            : base(converter)
        {
            _context = context;
            _self = self;
            _sender = sender;
        }

        public ActorOutVariable(ILogger logger, IActorContext context, IActorRef self, IActorRef sender, IConverter<TValue> converter = null)
            : base(logger, converter)
        {
            _context = context;
            _self = self;
            _sender = sender;
        }

        protected sealed override object getValue()
        {
            return getValue(_context, _self, _sender);
        }

        protected abstract object getValue(IActorContext context, IActorRef self, IActorRef sender);
    }
}
