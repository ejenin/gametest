using OpenTK.Input;
using System.Collections.Generic;

namespace Engine.Input
{
    public class KeyboardInput
    {
        private Dictionary<Key, bool> KeyStates { get; set; }
        private Dictionary<Key, bool> PreviousKeyStates { get; set; }

        public KeyboardInput()
        {
            KeyStates = new Dictionary<Key, bool>();
            PreviousKeyStates = new Dictionary<Key, bool>();
        }

        public void PressKey(Key key)
        {
            SafeSetState(key, true);
        }

        public void ReleaseKey(Key key)
        {
            SafeSetState(key, false);
        }

        private void SafeSetState(Key key, bool state)
        {
            if (KeyStates.ContainsKey(key))
            {
                KeyStates[key] = state;
            }
            else
            {
                KeyStates.Add(key, state);
            }
        }

        public bool IsKeyDown(Key key)
        {
            bool down = KeyStates.TryGetValue(key, out var result);
            return down && result;
        }

        public bool IsKeyPressed(Key key)
        {
            bool isInCurrent = KeyStates.TryGetValue(key, out var result);
            bool wasInPrevious = PreviousKeyStates.TryGetValue(key, out var prevResult);

            return result && !prevResult;
        }

        public bool IsKeyUp(Key key)
        {
            bool isInCurrent = KeyStates.TryGetValue(key, out var result);
            bool wasInPrevious = PreviousKeyStates.TryGetValue(key, out var prevResult);

            return !result && prevResult || (!result && !prevResult);
        }

        public void Update()
        {
            PreviousKeyStates.Clear();
            
            foreach (var item in KeyStates)
            {
                PreviousKeyStates.Add(item.Key, item.Value);
            }
        }
    }
}