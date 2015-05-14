import datetime
from pyramid.view import view_config
import mongo_perf.data as data

@view_config(route_name='home', renderer='templates/mytemplate.pt')
def my_view(request):
    return {'project': 'mongo_perf'}

@view_config(route_name='perf', renderer='templates/perf.pt')
def perf(request):
    d = data.get_data()
    count = d[0]
    book = d[1]
    #print(d)
    return {'count': count, 'book': book}