/*
 * ActorSelectionVariable.cs
 *
 * Copyright (c) 2019 aratomo-arazon
 *
 * This software is released under the MIT License.
 * http://opensource.org/licenses/mit-license.php
 */

using System;
using Akka.Actor;
using WFLite.Akka.Bases;
using WFLite.Interfaces;

namespace WFLite.Akka.Variables
{
    public class ActorSelectionVariable : ActorVariable
    {
        public IVariable ActorPath
        {
            private get;
            set;
        }

        public IVariable AnchorRef
        {
            private get;
            set;
        }

        public ActorSelectionVariable(IActorContext context, IActorRef self, IActorRef sender)
            : base(context, self, sender)
        {
        }

        public ActorSelectionVariable(IActorContext context, IActorRef self, IActorRef sender, IVariable actorPath, IVariable anchorRef = null, IConverter converter = null)
            : base(context, self, sender)
        {
            ActorPath = actorPath;
            AnchorRef = anchorRef;
            Converter = converter;
        }

        protected sealed override object getValue(IActorContext context, IActorRef self, IActorRef sender)
        {
            var actorPath = ActorPath.GetValue();

            if (actorPath is ActorPath)
            {
                return context.ActorSelection(actorPath as ActorPath);
            }
            else if (actorPath is string)
            {
                var anchorRef = AnchorRef.GetValue<IActorRef>();

                if (anchorRef != null)
                {
                    return context.ActorSelection(anchorRef, actorPath as string);
                }
                else
                {
                    return context.ActorSelection(actorPath as string);
                }
            }
            else
            {
                return null;
            }
        }

        protected sealed override void setValue(IActorContext context, IActorRef self, IActorRef sender, object value)
        {
            throw new NotSupportedException();
        }
    }
}
