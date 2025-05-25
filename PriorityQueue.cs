namespace DataStructures
{
    public class MinHeap
    {
        private List<int> _minHeap = new List<int>() { 0 };

        public MinHeap() {}

        public void Push(int val)
        {
            _minHeap.Add(val);

            var currentIndex = _minHeap.Count - 1;

            // Swim up.
            while (currentIndex > 1 && _minHeap[currentIndex] < _minHeap[currentIndex / 2])
            {
                var temporaryParentNodeValue = _minHeap[currentIndex / 2];
                _minHeap[currentIndex / 2] = _minHeap[currentIndex];
                _minHeap[currentIndex] = temporaryParentNodeValue;
                currentIndex = currentIndex / 2;
            }
        }

        public int? Pop()
        {
            if (_minHeap.Count <= 1)
                return -1;

            if (_minHeap.Count == 2)
            {
                var lastRemainingValue = _minHeap[1];
                _minHeap.RemoveAt(1);
                return lastRemainingValue;
            }

            var rootValue = _minHeap[1];
            _minHeap[1] = _minHeap[_minHeap.Count - 1];
            _minHeap.RemoveAt(_minHeap.Count - 1);

            var currentIndex = 1;

            // Swim down.
            while ((currentIndex * 2) < _minHeap.Count)
            {
                if ((currentIndex * 2) + 1 < _minHeap.Count &&
                    _minHeap[(currentIndex * 2) + 1] < _minHeap[currentIndex * 2] &&
                    _minHeap[(currentIndex * 2) + 1] < _minHeap[currentIndex])
                {
                    var temporaryRightChildValue = _minHeap[(currentIndex * 2) + 1];
                    _minHeap[(currentIndex * 2) + 1] = _minHeap[currentIndex];
                    _minHeap[currentIndex] = temporaryRightChildValue;
                    currentIndex = (currentIndex * 2) + 1;
                }
                else if (_minHeap[currentIndex * 2] < _minHeap[currentIndex])
                {
                    var temporaryLeftChildValue = _minHeap[currentIndex * 2];
                    _minHeap[currentIndex * 2] = _minHeap[currentIndex];
                    _minHeap[currentIndex] = temporaryLeftChildValue;
                    currentIndex = currentIndex * 2;
                }
                else
                {
                    break;
                }
            }

            return rootValue;
        }

        public int? Top()
        {
            return _minHeap.Count >= 2 ? _minHeap[1] : -1;
        }

        public void Heapify(List<int> nums)
        {
            if (nums.Count == 0)
                return;

            nums.Add(nums[0]);
            _minHeap = nums;

            int currentNode = (_minHeap.Count - 1) / 2;

            while (currentNode > 0)
            {
                var currentIndex = currentNode;

                while ((currentIndex * 2) < _minHeap.Count)
                {
                    if ((currentIndex * 2) + 1 < _minHeap.Count &&
                        _minHeap[(currentIndex * 2) + 1] < _minHeap[currentIndex * 2] &&
                        _minHeap[(currentIndex * 2) + 1] < _minHeap[currentIndex])
                    {
                        var temporaryRightChildValue = _minHeap[(currentIndex * 2) + 1];
                        _minHeap[(currentIndex * 2) + 1] = _minHeap[currentIndex];
                        _minHeap[currentIndex] = temporaryRightChildValue;
                        currentIndex = (currentIndex * 2) + 1;
                    }
                    else if (_minHeap[currentIndex * 2] < _minHeap[currentIndex])
                    {
                        var temporaryLeftChildValue = _minHeap[currentIndex * 2];
                        _minHeap[currentIndex * 2] = _minHeap[currentIndex];
                        _minHeap[currentIndex] = temporaryLeftChildValue;
                        currentIndex = currentIndex * 2;
                    }
                    else
                    {
                        break;
                    }
                }

                currentNode--;
            }
        }
    }
}
