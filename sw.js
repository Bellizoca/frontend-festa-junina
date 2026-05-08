const CACHE_NAME = 'arraial-cache-v1';
const ASSETS = [
    './',
    './index.html',
    './manifest.json',
    './assets/images/logo.png', // Lembre de atualizar essas imagens na sua pasta
    './assets/images/logopwa.png',
    './assets/images/logopwa512.png',
    './assets/images/banner.png',
    './assets/images/whatsapp.png'
];

self.addEventListener('install', (event) => {
    event.waitUntil(
        caches.open(CACHE_NAME).then((cache) => {
            // Mudando o log para o tema novo!
            console.log('Colocando o milho pra cozinhar no Cache! 🌽🔥');
            return cache.addAll(ASSETS);
        })
    );
});

self.addEventListener('fetch', (event) => {
    event.respondWith(
        caches.match(event.request).then((response) => {
            // Se tiver no cache, entrega. Se não, busca na rede.
            return response || fetch(event.request);
        })
    );
});

self.addEventListener('activate', (event) => {
    event.waitUntil(
        caches.keys().then((keys) => {
            return Promise.all(
                keys.filter(key => key !== CACHE_NAME)
                    .map(key => caches.delete(key))
            );
        })
    );
});
