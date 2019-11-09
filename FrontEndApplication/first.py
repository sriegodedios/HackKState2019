#! -*- coding: utf-8 -*-

import requests

# constants
RUN_URL = u'http://api.hackerearth.com/code/run/'
CLIENT_SECRET = 'd3ce6e50c86c80ad60f3e741c1db12c704d1c1a4'

source = "import sys;print(sys.path)"

data = {
    'client_secret': CLIENT_SECRET,
    'async': 0,
    'source': source,
    'lang': "PYTHON",
    'time_limit': 5,
    'memory_limit': 262144,
}

r = requests.post(RUN_URL, data=data)
print(r.json())