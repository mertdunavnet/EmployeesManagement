const CACHE_NAME = 'employee-app-cache-v2';
const urlsToCache = [
    '/',
    '/index.html',
    '/manifest.json',
    '/css/bootstrap/bootstrap.min.css',
    '/css/BlazorWASMProgressive.styles.css',
    '/css/app.css',
    '/favicon.ico',
    '/_framework/blazor.webassembly.js',
    '/_framework/blazor.boot.json',
    '/_framework/aspnetcore-browser-refresh.js',
    '/_framework/dotnet.7.0.19.mpc1d6k9dx.js',
];

self.addEventListener('install', (event) => {
    event.waitUntil(
        caches.open(CACHE_NAME).then((cache) => {
            return cache.addAll(urlsToCache);
        })
    );
});

self.addEventListener('fetch', (event) => {
    event.respondWith(
        caches.match(event.request).then((response) => {
            return response || fetch(event.request).catch(() => {
                return new Response('Service Unavailable', { status: 503 });
            });
        }).catch((error) => {
            console.error('Fetching failed:', error);
            throw error;
        })
    );
});
