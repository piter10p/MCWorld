﻿using MCWorld.Nbt.Abstractions.Tags;

namespace MCWorld.Nbt.Abstractions
{
    public interface INbtReader
    {
        public ITag GetNextTag();
    }
}
