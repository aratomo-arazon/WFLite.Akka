/*
 * ActorActivity.cs
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
    public abstract class ActorVariable : Variable
    {
        private readonly IActorContext _context;

        private readonly IActorRef _self;

        private readonly IActorRef _sender;

        public ActorVariable(IActorContext context, IActorRef self, IActorRef sender, IConverter converter = null)
            : base(converter)
        {
            _context = context;
            _self = self;
            _sender = sender;
        }

        protected sealed override object getValue()
        {
            return getValue(_context, _self, _sender);
        }

        protected sealed override void setValue(object value)
        {
            setValue(_context, _self, _sender, value);
        }

        protected abstract object getValue(IActorContext context, IActorRef self, IActorRef sender);

        protected abstract void setValue(IActorContext context, IActorRef self, IActorRef sender, object value);
    }

    public abstract class ActorVariable<TCategoryName> : LoggingVariable<TCategoryName>
    {
        private readonly IActorContext _context;

        private readonly IActorRef _self;

        private readonly IActorRef _sender;

        public ActorVariable(ILogger<TCategoryName> logger, IActorContext context, IActorRef self, IActorRef sender, IConverter converter = null)
            : base(logger, converter)
        {
            _context = context;
            _self = self;
            _sender = sender;
        }

        protected sealed override object getValue(ILogger<TCategoryName> logger)
        {
            return getValue(logger, _context, _self, _sender);
        }

        protected sealed override void setValue(ILogger<TCategoryName> logger, object value)
        {
            setValue(logger, _context, _self, _sender, value);
        }

        protected abstract object getValue(ILogger<TCategoryName> logger, IActorContext context, IActorRef self, IActorRef sender);

        protected abstract void setValue(ILogger<TCategoryName> logger, IActorContext context, IActorRef self, IActorRef sender, object value);
    }
}
