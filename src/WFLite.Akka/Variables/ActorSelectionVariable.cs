/*
 * ActorSelectionVariable.cs
 *
 * Copyright (c) 2019 aratomo-arazon
 *
 * This software is released under the MIT License.
 * http://opensource.org/licenses/mit-license.php
 */

using Akka.Actor;
using WFLite.Akka.Bases;
using WFLite.Interfaces;

namespace WFLite.Akka.Variables
{
    public class ActorSelectionVariable : ActorOutVariable<ActorSelection>
    {
        public IOutVariable ActorPath
        {
            private get;
            set;
        }

        public IOutVariable<IActorRef> AnchorRef
        {
            private get;
            set;
        }

        public ActorSelectionVariable(IActorContext context, IActorRef self, IActorRef sender)
            : base(context, self, sender)
        {
        }

        public ActorSelectionVariable(IActorContext context, IActorRef self, IActorRef sender, IOutVariable actorPath, IOutVariable<IActorRef> anchorRef = null)
            : base(context, self, sender)
        {
            ActorPath = actorPath;
            AnchorRef = anchorRef;
        }

        protected sealed override object getValue(IActorContext context, IActorRef self, IActorRef sender)
        {
            var actorPath = ActorPath.GetValueAsObject();

            if (actorPath is ActorPath)
            {
                return context.ActorSelection(actorPath as ActorPath);
                
            }
            else if (actorPath is string)
            {
                var anchorRef = AnchorRef.GetValue();

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
    }
}
