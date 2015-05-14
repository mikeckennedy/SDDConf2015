import datetime
import requests
import statistics

def main():
    aspnet_url = 'http://localhost:54699/Home/PerfTest'
    python_url = 'http://127.0.0.1:6543/perf'
    check_perf(aspnet_url, 'ASP.NET')
    print()
    check_perf(python_url, 'Python')

def check_perf(url, name):
    print("Checking perf for " + name)
    requests.get(url)
    requests.get(url)

    results = []

    for i in range(0, 1000):
        if i % 20 == 0:
            print('.', end='')
        t0 = datetime.datetime.now()

        response = requests.get(url)
        if response.status_code != 200:
            print("oops, error! {}" + response.status_code )

        t1 = datetime.datetime.now()

        dt = t1 - t0
        results.append(dt.total_seconds()*1000.0)

    print()

    print("Mean: {0:.3} ms.".format(statistics.mean(results)))
    print("Median: {0:.3} ms.".format(statistics.median(results)))
    print("Standard deviation: {0:.3} ms.".format(statistics.pstdev(results)))

    print("done!")

if __name__ == '__main__':
    main()

