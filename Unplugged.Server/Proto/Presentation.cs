
    namespace UnpluggedModel
    {
        public partial class Presentation
        {

            public string _EventId
            {
                get => EventId == "" ? null : EventId;
                set => EventId = value ?? "";
            }

        }
    }
